using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Newarr)]
        public static void Newarr(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Newarr is not implemented");
        }
    }
}