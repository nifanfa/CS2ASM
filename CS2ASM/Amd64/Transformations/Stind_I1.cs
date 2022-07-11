using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Stind_I1)]
        public static void Stind_I1(Context context)
        {
            context.Pop($"rdx");
            context.Pop($"rax");
            context.StackOperationCount -= 2;
            context.Append($"mov [rax],dl");
        }
    }
}
