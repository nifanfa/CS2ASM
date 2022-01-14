using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Stloc)]
        public static void Stloc(Context context)
        {
            ulong Index = OperandParser.Stloc(context.ins) + 1;
            context.Append($"pop rax");
            context.Append($"mov [rbp-{Index * 8}],rax");
        }
    }
}
