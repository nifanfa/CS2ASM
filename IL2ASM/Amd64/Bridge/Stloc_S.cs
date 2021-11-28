using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Stloc_S)]
        public static void Stloc_S(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Stloc_S is not implemented");
        }
    }
}
