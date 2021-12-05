using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Clt)]
        public static void Clt(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"pop rdx");
            arch.Append($"pop rax");
            arch.Append($"cmp rax,rdx");
            arch.Append($"jb $+6");
            arch.Append($"push 0");
            arch.Append($"jmp $+4");
            arch.Append($"push 1");
        }
    }
}
