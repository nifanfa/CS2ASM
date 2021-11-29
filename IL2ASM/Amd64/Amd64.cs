/*
 * Reference: 
 * https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/x64-architecture
 * https://docs.microsoft.com/zh-cn/dotnet/api/system.reflection.emit.opcodes?view=net-6.0
*/

using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Linq;
using System.Reflection;

namespace IL2ASM
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

            //for call
            if (!isEntryPoint)
            {
                this.Append($"pop rax");
            }
            this.Append($"mov rbp,stack_bottom");
            this.Append($"mov rsp,rbp");
            if (!isEntryPoint)
            {
                this.Append($"mov [rbp+8],rax");
            }

            //For Variables
            if (def.Body.Variables.Count != 0)
                this.Append($"xor rax,rax");

            for (ulong i = 0; i < (ulong)def.Body.Variables.Count; i++)
            {
                this.Append($"push rax");
            }

            //Start Parse IL Code
            for (int i = 0; i < def.Body.Instructions.Count; i++)
            {
                var ins = def.Body.Instructions[i];

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

                this.Append();
            }
        }
    }
}
