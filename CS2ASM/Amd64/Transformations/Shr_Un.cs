using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Shr_Un)]
        public static void Shr_Un(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            context.Append($"xor rdx,rdx");
            context.Append($"pop rcx");
            context.Append($"pop rax");
            context.Append($"shr rax,cl");
            context.Append($"push rax");
        }
    }
}
