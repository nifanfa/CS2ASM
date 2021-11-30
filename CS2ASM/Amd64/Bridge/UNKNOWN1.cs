using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.UNKNOWN1)]
        public static void UNKNOWN1(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("UNKNOWN1 is not implemented");
        }
    }
}
