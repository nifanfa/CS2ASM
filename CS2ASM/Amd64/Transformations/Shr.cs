using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Shr)]
        public static void Shr(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"pop rcx");
            arch.Append($"pop rax");
            arch.Append($"shr rax,cl");
            arch.Append($"push rax");
        }
    }
}
