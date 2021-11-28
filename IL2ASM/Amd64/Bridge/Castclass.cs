using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Castclass)]
        public static void Castclass(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Castclass is not implemented");
        }
    }
}
