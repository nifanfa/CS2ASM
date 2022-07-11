using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Shr)]
        public static void Shr(Context context)
        {
            context.Append($"xor rdx,rdx");
            context.Pop($"rcx");
            context.Pop($"rax");
            context.StackOperationCount -= 2;
            context.Append($"shr rax,cl");
            context.Push($"rax");
            context.StackOperationCount += 1;
        }
    }
}
