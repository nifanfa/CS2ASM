using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Or)]
        public static void Or(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            context.Append($"xor rdx,rdx");
            context.Append($"pop rdx");
            context.Append($"pop rax");
            context.Append($"or rax,rdx");
            context.Append($"push rax");
        }
    }
}
