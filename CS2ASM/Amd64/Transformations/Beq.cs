using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Beq)]
        public static void Beq(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            //WIP
            context.Append($"pop rdx");
            context.Append($"pop rax");
            context.Append($"cmp rax,rdx");
            context.Append($"je {Utility.BrLabelName(ins, def)}");
        }
    }
}
