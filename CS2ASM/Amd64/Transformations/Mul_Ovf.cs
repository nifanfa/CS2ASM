using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Mul_Ovf)]
        public static void Mul_Ovf(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Mul_Ovf is not implemented");
        }
    }
}
