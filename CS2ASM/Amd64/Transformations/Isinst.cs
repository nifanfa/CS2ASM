using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Isinst)]
        public static void Isinst(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Isinst is not implemented");
        }
    }
}
