using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Rem)]
        public static void Rem(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Rem is not implemented");
        }
    }
}
