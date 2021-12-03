using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Ldarg_3)]
        public static void Ldarg_3(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"push qword [rbp+{((ulong)def.Parameters.Count + 1 - OperandParser.Ldarg(ins)) * 8}]");
        }
    }
}
