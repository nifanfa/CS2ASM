using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldloc)]
        public static void Ldloc(Context context)
        {
            ulong Index = OperandParser.Ldloc(context.ins) + 1;
            context.Append($"mov qword rax,[rbp-{((ulong)context.def.MethodSig.Params.Count + (ulong)(context.def.MethodSig.HasThis ? 1 : 0) + Index) * 8}]");
            context.Push($"rax");
            context.StackOperationCount += 1;
        }
    }
}
