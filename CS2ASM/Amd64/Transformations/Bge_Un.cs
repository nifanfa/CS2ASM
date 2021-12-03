using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Bge_Un)]
        public static void Bge_Un(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Bge_Un is not implemented");
        }
    }
}
