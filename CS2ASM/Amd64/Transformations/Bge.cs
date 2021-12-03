using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Bge)]
        public static void Bge(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Bge is not implemented");
        }
    }
}
