using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Div_Un)]
        public static void Div_Un(Context context)
        {
            context.Append($"xor rdx,rdx");
            context.Append($"pop rbx");
            context.Append($"pop rax");
            context.StackOperationCount -= 2;
            context.Append($"div rbx");
            context.Append($"push rax");
            context.StackOperationCount += 1;
        }
    }
}
