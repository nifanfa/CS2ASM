using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Conv_I1)]
        public static void Conv_I1(Context context)
        {
            context.Append($"xor rdx,rdx");
            context.Append($"mov rbx,0xFF");
            context.Pop($"rax");
            context.StackOperationCount -= 1;
            context.Append($"and rax,rbx");
            context.Push($"rax");
            context.StackOperationCount += 1;
        }
    }
}
