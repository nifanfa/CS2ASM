using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.UNKNOWN1)]
        public static void UNKNOWN1(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("UNKNOWN1 is not implemented");
        }
    }
}
