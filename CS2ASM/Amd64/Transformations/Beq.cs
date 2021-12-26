using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Beq)]
        public static void Beq(BaseArch arch, Instruction ins, MethodDef def)
        {
            //WIP
            arch.Append($"pop rdx");
            arch.Append($"pop rax");
            arch.Append($"cmp rax,rdx");
            arch.Append($"je {Utility.BrLabelName(ins, def)}");
        }
    }
}
