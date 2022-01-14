using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Blt)]
        public static void Blt(Context context)
        {
            context.Append($"pop rdx");
            context.Append($"pop rax");
            context.Append($"cmp rax,rdx");
            context.Append($"jb {Utility.BrLabelName(context.ins, context.def)}");
        }
    }
}
