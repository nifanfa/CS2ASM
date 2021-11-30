using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Bgt_S)]
        public static void Bgt_S(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Bgt_S is not implemented");
        }
    }
}
