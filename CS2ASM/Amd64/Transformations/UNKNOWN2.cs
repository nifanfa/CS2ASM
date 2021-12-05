using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.UNKNOWN2)]
        public static void UNKNOWN2(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("UNKNOWN2 is not implemented");
        }
    }
}
