using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Brtrue)]
        public static void Brtrue(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Brtrue is not implemented");
        }
    }
}
