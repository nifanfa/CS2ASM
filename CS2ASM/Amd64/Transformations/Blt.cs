using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Blt)]
        public static void Blt(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Blt is not implemented");
        }
    }
}
