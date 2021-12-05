using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Initblk)]
        public static void Initblk(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Initblk is not implemented");
        }
    }
}
