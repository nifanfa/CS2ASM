using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Stelem_I)]
        public static void Stelem_I(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Stelem_I is not implemented");
        }
    }
}
