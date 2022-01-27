using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Shr_Un)]
        public static void Shr_Un(Context context)
        {
            context.Append($"xor rdx,rdx");
            context.Append($"pop rcx");
            context.Append($"pop rax");
            context.StackOperationCount -= 2;
            context.Append($"shr rax,cl");
            context.Append($"push rax");
            context.StackOperationCount += 1;
        }
    }
}
