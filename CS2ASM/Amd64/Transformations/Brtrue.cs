using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Brtrue)]
        public static void Brtrue(Context context)
        {
            context.Pop($"rax");
            context.StackOperationCount -= 1;
            context.Append($"cmp rax,0");
            context.Append($"jne {Utility.BrLabelName(context.ins, context.def)}");
        }
    }
}
