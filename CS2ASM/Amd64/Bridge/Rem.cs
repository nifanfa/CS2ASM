using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Rem)]
        public static void Rem(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Rem is not implemented");
        }
    }
}
