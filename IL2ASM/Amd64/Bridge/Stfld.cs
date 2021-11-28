using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Stfld)]
        public static void Stfld(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Stfld is not implemented");
        }
    }
}