using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldc_I4_M1)]
        public static void Ldc_I4_M1(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldc_I4_M1 is not implemented");
        }
    }
}
