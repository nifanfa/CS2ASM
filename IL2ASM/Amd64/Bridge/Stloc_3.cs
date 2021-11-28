using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Stloc_3)]
        public static void Stloc_3(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Stloc_3 is not implemented");
        }
    }
}
