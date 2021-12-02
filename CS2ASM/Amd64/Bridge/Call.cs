using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Call)]
        public static void Call(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"call {Amd64.SafeMethodName(((MethodDef)ins.Operand))}");

            //Clean up arguments
            for (int i = 0; i < ((MethodDef)ins.Operand).Parameters.Count; i++)
            {
                arch.Append($"pop rcx");
            }
            arch.Append($"pop rbp"); //Recover rbp register

            //Ret.cs
            if (def.HasReturnType)
            {
                arch.Append($"push rax");
            }
        }
    }
}
