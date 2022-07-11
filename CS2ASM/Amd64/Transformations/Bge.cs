using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Bge)]
        public static void Bge(Context context)
        {
            context.Pop($"rdx");
            context.Pop($"rax");
            context.StackOperationCount -= 2;
            context.Append($"cmp rax,rdx");
            context.Append($"jae {Utility.BrLabelName(context.ins, context.def)}");
        }
    }
}
