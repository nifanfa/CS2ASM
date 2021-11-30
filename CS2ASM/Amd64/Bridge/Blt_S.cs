using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Blt_S)]
        public static void Blt_S(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Blt_S is not implemented");
        }
    }
}
