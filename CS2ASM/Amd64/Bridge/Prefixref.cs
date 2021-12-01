using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Prefixref)]
        public static void Prefixref(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Prefixref is not implemented");
        }
    }
}
