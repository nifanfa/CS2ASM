using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Starg_S)]
        public static void Starg_S(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Starg_S is not implemented");
        }
    }
}
