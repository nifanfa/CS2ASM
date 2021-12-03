using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Prefix4)]
        public static void Prefix4(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Prefix4 is not implemented");
        }
    }
}
