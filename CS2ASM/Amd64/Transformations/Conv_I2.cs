using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Conv_I2)]
        public static void Conv_I2(Context context)
        {
            context.Append($"xor rdx,rdx");
            context.Append($"mov rbx,0xFFFF");
            context.Append($"pop rax");
            context.StackOperationCount -= 1;
            context.Append($"and rax,rbx");
            context.Append($"push rax");
            context.StackOperationCount += 1; 
        }
    }
}
