using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ceq)]
        public static void Ceq(Context context)
        {
            context.Append($"xor rbx,rbx");
            context.Append($"pop rdx");
            context.Append($"pop rax");
            context.StackOperationCount -= 2;
            context.Append($"cmp rax,rdx");
            context.Append($"sete bl");
            context.Append($"push rbx");
            context.StackOperationCount += 1;
        }
    }
}
