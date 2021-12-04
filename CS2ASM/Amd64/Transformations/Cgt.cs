using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    { 
        [ILTransformation(Code.Cgt)]
        public static void Cgt(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"pop rdx");
            arch.Append($"pop rax");
            arch.Append($"cmp rax,rdx");
            arch.Append($"ja $+6");
            arch.Append($"push 0");
            arch.Append($"jmp $+4");
            arch.Append($"push 1");
        }
    }
}
