using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Prefix1)]
        public static void Prefix1(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Prefix1 is not implemented");
        }
    }
}
