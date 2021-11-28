using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Sub)]
        public static void Sub(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Sub is not implemented");
        }
    }
}
