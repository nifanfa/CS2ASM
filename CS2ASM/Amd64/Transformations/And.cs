using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.And)]
        public static void And(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"xor rdx,rdx");
            arch.Append($"pop rdx");
            arch.Append($"pop rax");
            arch.Append($"and rax,rdx");
            arch.Append($"push rax");
        }
    }
}
