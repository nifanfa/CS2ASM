using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Shl)]
        public static void Shl(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"xor rdx,rdx");
            arch.Append($"pop rcx");
            arch.Append($"pop rax");
            arch.Append($"shl rax,cl");
            arch.Append($"push rax");
        }
    }
}
