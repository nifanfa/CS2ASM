using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Beq_S)]
        public static void Beq_S(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Beq_S is not implemented");
        }
    }
}
