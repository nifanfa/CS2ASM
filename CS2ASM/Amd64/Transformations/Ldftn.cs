using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldftn)]
        public static void Ldftn(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldftn is not implemented");
        }
    }
}
