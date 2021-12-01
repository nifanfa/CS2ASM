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
    public unsafe class Amd64 : BaseArch
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
            this.Append($"{SafeMethodName(def)}:");

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
                        this.Append($"{BrLabelName(ins, def, true)}:");
                }

                //Compile IL Instructions
                ILBridgeMethods[ins.OpCode.Code].Invoke(null, new object[] { this, ins, def });
            }
        }

        public override void InitFields(TypeDef typ)
        {
            foreach(var v in typ.Fields) 
            {
                //Ldsfld
                //Stsfld
                this.Append($";{v}");
                this.Append($"{SafeFieldName(typ, v)}:");
                this.Append($"dq 0");
            }
        }


        public static string SafeMethodName(MethodDef meth)
        {
            return $"{meth.DeclaringType.Namespace}_{meth.DeclaringType.Name}_{meth.Name}";
        }

        public static string SafeFieldName(TypeDef type, FieldDef field)
        {
            return $"{type.Namespace}_{field.Name}";
        }

        public static string BrLabelName(Instruction ins, MethodDef def, bool Create = false)
        {
            return $"{SafeMethodName(def)}_IL_{(Create ? ins.Offset : (((Instruction)(ins.Operand)).Offset)):X4}";
        }
    }
}
