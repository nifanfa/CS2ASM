using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Conv_I)]
        public static void Conv_I(Context context)
        {
            context.Append($"xor rdx,rdx");
            context.Append($"mov rbx,0xFFFFFFFF");
            context.Pop($"rax");
            context.StackOperationCount -= 1;
            context.Append($"and rax,rbx");
            context.Push($"rax");
            context.StackOperationCount += 1;
        }
    }
}
