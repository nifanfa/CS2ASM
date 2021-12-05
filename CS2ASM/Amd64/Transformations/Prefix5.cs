using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Prefix5)]
        public static void Prefix5(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Prefix5 is not implemented");
        }
    }
}
