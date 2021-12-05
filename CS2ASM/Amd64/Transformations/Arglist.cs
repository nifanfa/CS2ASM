using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Arglist)]
        public static void Arglist(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Arglist is not implemented");
        }
    }
}
