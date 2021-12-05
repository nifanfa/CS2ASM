using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Mkrefany)]
        public static void Mkrefany(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Mkrefany is not implemented");
        }
    }
}
