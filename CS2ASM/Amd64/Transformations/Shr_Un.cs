using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Shr_Un)]
        public static void Shr_Un(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Shr_Un is not implemented");
        }
    }
}
