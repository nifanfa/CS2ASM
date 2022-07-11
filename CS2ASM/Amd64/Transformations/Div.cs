using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Div)]
        public static void Div(Context context)
        {
            context.Append($"xor rdx,rdx");
            context.Pop($"rbx");
            context.Pop($"rax");
            context.StackOperationCount -= 2;
            context.Append($"idiv rbx");
            context.Push($"rax");
            context.StackOperationCount += 1;
        }
    }
}
