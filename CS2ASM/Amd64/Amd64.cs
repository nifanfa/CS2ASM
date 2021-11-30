/*
 * Reference: 
 * https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/x64-architecture
 * https://docs.microsoft.com/zh-cn/dotnet/api/system.reflection.emit.opcodes?view=net-6.0
*/

using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Linq;
using System.Reflection;

namespace CS2ASM
{
    public unsafe class Amd64 : Arch
    {
        public override void Setup()
        {
            var methodInfos = from M in typeof(Amd64Bridge).GetMethods()
                              where M.GetCustomAttribute(typeof(ILBridgeAttribute), true) != null
                              select M;
            foreach (var v in methodInfos)
            {
                ILBridgeMethods.Add(v.GetCustomAttributes(true).OfType<ILBridgeAttribute>().First().code, v);
            }

            this.Append($"[bits 64]");
        }

        public override void Compile(MethodDef def, bool isEntryPoint = false)
        {

            //Get All Branches
            var BrS = from Br in def.Body.Instructions
                      where
(
Br.OpCode.Code == Code.Br ||
Br.OpCode.Code == Code.Brfalse ||
Br.OpCode.Code == Code.Brfalse_S ||
Br.OpCode.Code == Code.Brtrue ||
Br.OpCode.Code == Code.Brtrue_S ||
Br.OpCode.Code == Code.Br_S)
                      select Br;

            //Label
            this.Append($"{def.SafeMethodName()}:");

            if (isEntryPoint)
            {
                this.Append($"mov rbp,stack_bottom");
                this.Append($"mov rsp,rbp");
            }

            this.Append($"mov [cache-16],rbp");
            this.Append($"mov rbp,rsp");

            //for call
            if (!isEntryPoint)
            {
                this.Append($"pop rcx");
                this.Append($"mov [cache-8],rcx");
            }

            //For Variables
            //pop at Ret.cs
            for (ulong i = 0; i < (ulong)def.Body.Variables.Count; i++)
            {
                this.Append($"push 0");
            }

            //Start Parse IL Code
            for (int i = 0; i < def.Body.Instructions.Count; i++)
            {
                var ins = def.Body.Instructions[i];

                if (Debug)
                    this.Append($";{ins}");

                //For Branches
                foreach (var v in BrS)
                {
                    if (((Instruction)v.Operand).Offset == ins.Offset)
                        this.Append($"{Util.BrLabelName(ins, def, true)}:");
                }

                //Starts Here
                //Bridge
                if (ILBridgeMethods.ContainsKey(ins.OpCode.Code))
                {
                    ILBridgeMethods[ins.OpCode.Code].Invoke(null, new object[] { this, ins, def });
                }

                if (Debug)
                    this.Append();
            }
        }
    }
}
