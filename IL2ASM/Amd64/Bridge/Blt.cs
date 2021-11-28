using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Blt)]
        public static void Blt(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Blt is not implemented");
        }
    }
}
