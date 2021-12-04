using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Localloc)]
        public static void Localloc(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Localloc is not implemented");
        }
    }
}
