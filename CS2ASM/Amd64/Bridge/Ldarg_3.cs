using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldarg_3)]
        public static void Ldarg_3(Arch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"push qword [rbp+{((ulong)def.Parameters.Count - OperandReader.Ldarg(ins)) * 8}]");
        }
    }
}
