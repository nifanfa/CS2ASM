using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Clt)]
        public static void Clt(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"xor rbx,rbx");
            arch.Append($"pop rdx");
            arch.Append($"pop rax");
            arch.Append($"cmp rax,rdx");
            arch.Append($"setl bl");
            arch.Append($"push rbx");
        }
    }
}
