using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Shr)]
        public static void Shr(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Shr is not implemented");
        }
    }
}
