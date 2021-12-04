using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldind_R4)]
        public static void Ldind_R4(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldind_R4 is not implemented");
        }
    }
}
