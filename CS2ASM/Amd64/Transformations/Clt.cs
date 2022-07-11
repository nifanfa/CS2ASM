using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Clt)]
        public static void Clt(Context context)
        {
            context.Append($"xor rbx,rbx");
            context.Pop($"rdx");
            context.Pop($"rax");
            context.StackOperationCount -= 2;
            context.Append($"cmp rax,rdx");
            context.Append($"setl bl");
            context.Push($"rbx");
            context.StackOperationCount += 1;
        }
    }
}
