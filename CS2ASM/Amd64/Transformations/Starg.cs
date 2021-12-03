using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Starg)]
        public static void Starg(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Starg is not implemented");
        }
    }
}
