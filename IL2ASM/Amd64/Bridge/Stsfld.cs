using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Stsfld)]
        public static void Stsfld(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Stsfld is not implemented");
        }
    }
}
