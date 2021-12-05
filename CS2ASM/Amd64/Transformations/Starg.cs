using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Starg)]
        public static void Starg(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Starg is not implemented");
        }
    }
}
