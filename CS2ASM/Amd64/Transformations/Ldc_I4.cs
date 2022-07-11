using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldc_I4)]
        public static void Ldc_I4(Context context)
        {
            context.Append($"mov rax,{OperandParser.Ldc(context.ins)}");
            context.Append($"push rax");
            context.StackOperationCount += 1;
        }
    }
}
