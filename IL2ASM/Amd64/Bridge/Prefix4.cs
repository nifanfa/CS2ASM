using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Prefix4)]
        public static void Prefix4(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Prefix4 is not implemented");
        }
    }
}
