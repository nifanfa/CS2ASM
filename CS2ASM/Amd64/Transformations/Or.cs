using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Or)]
        public static void Or(Context context)
        {
            context.Append($"xor rdx,rdx");
            context.Pop($"rdx");
            context.Pop($"rax");
            context.StackOperationCount -= 2;
            context.Append($"or rax,rdx");
            context.Push($"rax");
            context.StackOperationCount += 1;
        }
    }
}
