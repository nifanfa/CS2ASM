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
            context.Pop($"rax");
            context.StackOperationCount -= 1;
            context.Append($"mov [rbp-{((ulong)context.def.MethodSig.Params.Count + (ulong)(context.def.MethodSig.HasThis ? 1 : 0) + Index) * 8}],rax");
        }
    }
}
