using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Dup)]
        public static void Dup(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Dup is not implemented");
        }
    }
}
