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

            arch.Append($"pop rbp"); //Recover rbp register
            //Clean up arguments
            for (int i = 0; i < ((MethodDef)ins.Operand).Parameters.Count; i++)
            {
                arch.Append($"pop rcx");
            }

            //Ret.cs
            if (def.HasReturnType)
            {
                arch.Append($"push rax");
            }
        }
    }
}
