using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Bge_S)]
        public static void Bge_S(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Bge_S is not implemented");
        }
    }
}