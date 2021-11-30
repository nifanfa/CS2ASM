using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Constrained)]
        public static void Constrained(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Constrained is not implemented");
        }
    }
}
