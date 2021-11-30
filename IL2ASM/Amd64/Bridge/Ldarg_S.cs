using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldarg_S)]
        public static void Ldarg_S(Arch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"push qword [rbp+{((OperandReader.Ldarg(ins) + 1) * 8)}]");
        }
    }
}
