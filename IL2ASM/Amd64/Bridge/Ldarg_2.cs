using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldarg_2)]
        public static void Ldarg_2(Arch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"push qword [rbp+{((OperandReader.Ldarg(ins) + 1) * 8)}]");
        }
    }
}
