using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Prefix7)]
        public static void Prefix7(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Prefix7 is not implemented");
        }
    }
}
