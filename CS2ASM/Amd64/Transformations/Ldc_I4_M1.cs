using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldc_I4_M1)]
        public static void Ldc_I4_M1(BaseArch arch, Instruction ins, MethodDef def)
        {
            Ldc_I4(arch, ins, def);
        }
    }
}
