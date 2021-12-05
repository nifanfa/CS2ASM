using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Constrained)]
        public static void Constrained(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Constrained is not implemented");
        }
    }
}
