using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Beq_S)]
        public static void Beq_S(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Beq_S is not implemented");
        }
    }
}
