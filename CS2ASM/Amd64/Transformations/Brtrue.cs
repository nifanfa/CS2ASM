using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Brtrue)]
        public static void Brtrue(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            context.Append($"pop rax");
            context.Append($"cmp rax,0");
            context.Append($"jne {Utility.BrLabelName(ins, def)}");
        }
    }
}
