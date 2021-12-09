using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Starg)]
        public static void Starg(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"pop rax");
            arch.Append($"mov [rbp+{((ulong)def.Parameters.Count + 1 - OperandParser.Starg(ins)) * 8}],rax");
        }
    }
}
