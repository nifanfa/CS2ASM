using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Stelem_R8)]
        public static void Stelem_R8(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Stelem_R8 is not implemented");
        }
    }
}
