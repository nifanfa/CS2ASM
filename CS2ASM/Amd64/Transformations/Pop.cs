using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Pop)]
        public static void Pop(Context context)
        {
            context.Append($"add rsp,8");
            context.StackOperationCount -= 1;
        }
    }
}
