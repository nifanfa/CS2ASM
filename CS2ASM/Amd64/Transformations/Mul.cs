using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Mul)]
        public static void Mul(Context context)
        {
            context.Append($"xor rdx,rdx");
            context.Append($"pop rbx");
            context.Append($"pop rax");
            context.StackOperationCount -= 2;
            context.Append($"imul rbx");
            context.Append($"push rax");
            context.StackOperationCount += 1;
        }
    }
}
