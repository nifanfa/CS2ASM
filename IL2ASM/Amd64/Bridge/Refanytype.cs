using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Refanytype)]
        public static void Refanytype(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Refanytype is not implemented");
        }
    }
}
