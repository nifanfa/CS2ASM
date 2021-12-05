using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldsflda)]
        public static void Ldsflda(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldsflda is not implemented");
        }
    }
}
