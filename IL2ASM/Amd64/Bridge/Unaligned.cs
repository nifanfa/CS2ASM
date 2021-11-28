using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Unaligned)]
        public static void Unaligned(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Unaligned is not implemented");
        }
    }
}
