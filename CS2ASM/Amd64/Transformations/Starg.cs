using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Starg)]
        public static void Starg(Context context)
        {
            context.Pop($"rax");
            context.StackOperationCount -= 1;
            context.Append($"mov [rbp-{((ulong)context.def.Parameters.Count + 0 - OperandParser.Starg(context.ins)) * 8}],rax");
        }
    }
}
