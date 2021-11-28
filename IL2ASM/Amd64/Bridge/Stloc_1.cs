using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Stloc_1)]
        public static void Stloc_1(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Stloc_1 is not implemented");
        }
    }
}
