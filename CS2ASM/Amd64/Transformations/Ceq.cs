using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ceq)]
        public static void Ceq(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"xor rbx,rbx");
            arch.Append($"pop rdx");
            arch.Append($"pop rax");
            arch.Append($"cmp rax,rdx");
            arch.Append($"sete bl");
            arch.Append($"push rbx");
        }
    }
}
