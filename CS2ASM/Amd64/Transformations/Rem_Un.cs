using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Rem_Un)]
        public static void Rem_Un(Context context)
        {
            context.Append($"xor rdx,rdx");
            context.Pop($"rbx");
            context.Pop($"rax");
            context.StackOperationCount -= 2;
            context.Append($"div rbx");
            context.Push($"rdx");
            context.StackOperationCount += 1;
        }
    }
}
