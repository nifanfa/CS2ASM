using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Ldind_R8)]
        public static void Ldind_R8(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldind_R8 is not implemented");
        }
    }
}
