using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Leave)]
        public static void Leave(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Leave is not implemented");
        }
    }
}
