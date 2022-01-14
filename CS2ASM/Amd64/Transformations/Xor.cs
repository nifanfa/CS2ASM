using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Xor)]
        public static void Xor(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            context.Append($"pop rdx");
            context.Append($"pop rax");
            context.Append($"xor rax,rdx");
            context.Append($"push rax");
        }
    }
}
