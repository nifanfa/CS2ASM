using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Neg)]
        public static void Neg(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Neg is not implemented");
        }
    }
}
