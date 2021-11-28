using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Beq)]
        public static void Beq(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Beq is not implemented");
        }
    }
}
