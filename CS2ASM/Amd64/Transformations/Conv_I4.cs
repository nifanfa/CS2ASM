using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Conv_I4)]
        public static void Conv_I4(Context context)
        {
            context.Append($"xor rdx,rdx");
            context.Append($"mov rbx,0xFFFFFFFF");
            context.Append($"pop rax");
            context.Append($"and rax,rbx");
            context.Append($"push rax");
        }
    }
}
