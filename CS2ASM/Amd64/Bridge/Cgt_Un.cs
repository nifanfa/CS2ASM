using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Cgt_Un)]
        public static void Cgt_Un(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Cgt_Un is not implemented");
        }
    }
}
