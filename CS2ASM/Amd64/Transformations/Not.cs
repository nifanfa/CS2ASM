using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Not)]
        public static void Not(Context context)
        {
            context.Append($"pop rax");
            context.Append($"not rax");
            context.Append($"push rax");
        }
    }
}
