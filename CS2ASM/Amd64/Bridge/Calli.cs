using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Calli)]
        public static void Calli(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Calli is not implemented");
        }
    }
}
