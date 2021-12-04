using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Bgt_S)]
        public static void Bgt_S(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Bgt_S is not implemented");
        }
    }
}
