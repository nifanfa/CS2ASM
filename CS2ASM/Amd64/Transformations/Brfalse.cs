using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Brfalse)]
        public static void Brfalse(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"pop rax");
            arch.Append($"cmp rax,0");
            arch.Append($"je {Utility.BrLabelName(ins, def)}");
        }
    }
}
