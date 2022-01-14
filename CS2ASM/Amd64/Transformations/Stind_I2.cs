using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Stind_I2)]
        public static void Stind_I2(Context context)
        {
            context.Append($"pop rdx");
            context.Append($"pop rax");
            context.Append($"mov [rax],dx");
        }
    }
}
