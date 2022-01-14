using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Shl)]
        public static void Shl(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            context.Append($"xor rdx,rdx");
            context.Append($"pop rcx");
            context.Append($"pop rax");
            context.Append($"shl rax,cl");
            context.Append($"push rax");
        }
    }
}
