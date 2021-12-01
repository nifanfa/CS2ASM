using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Cpblk)]
        public static void Cpblk(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Cpblk is not implemented");
        }
    }
}
