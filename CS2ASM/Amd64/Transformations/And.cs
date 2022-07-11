using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.And)]
        public static void And(Context context)
        {
            context.Append($"xor rdx,rdx");
            context.Pop($"rdx");
            context.Pop($"rax");
            context.StackOperationCount -= 2;
            context.Append($"and rax,rdx");
            context.Push($"rax");
            context.StackOperationCount += 1;
        }
    }
}
