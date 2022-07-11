using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Neg)]
        public static void Neg(Context context)
        {
            context.Pop("rbx");
            context.StackOperationCount -= 1;
            context.Append("xor rdx,rdx");
            context.Append("neg rbx");
            context.Push("rbx");
            context.StackOperationCount += 1;
        }
    }
}
