using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Brfalse)]
        public static void Brfalse(Context context)
        {
            context.Pop($"rax");
            context.StackOperationCount -= 1;
            context.Append($"cmp rax,0");
            context.Append($"je {Utility.BrLabelName(context.ins, context.def)}");
        }
    }
}
