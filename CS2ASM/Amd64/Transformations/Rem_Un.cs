using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Rem_Un)]
        public static void Rem_Un(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Rem_Un is not implemented");
        }
    }
}
