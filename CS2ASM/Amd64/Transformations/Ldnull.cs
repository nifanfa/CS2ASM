using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldnull)]
        public static void Ldnull(BaseArch arch, Instruction ins, MethodDef def)
        {
            //Here can be implementation of disposing
            arch.Append($"push qword 0");
        }
    }
}
