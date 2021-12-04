using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Blt_Un)]
        public static void Blt_Un(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Blt_Un is not implemented");
        }
    }
}
