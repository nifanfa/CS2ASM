using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Xor)]
        public static void Xor(Context context)
        {
            context.Pop($"rdx");
            context.Pop($"rax");
            context.StackOperationCount -= 2;
            context.Append($"xor rax,rdx");
            context.Push($"rax");
            context.StackOperationCount += 1;
        }
    }
}
