using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldc_I8)]
        public static void Ldc_I8(Context context)
        {
            context.Append($"mov rax,{OperandParser.Ldc(context.ins)}");
            context.Push($"rax");
            context.StackOperationCount += 1;
        }
    }
}
