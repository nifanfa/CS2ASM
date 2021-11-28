using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Bgt_Un)]
        public static void Bgt_Un(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Bgt_Un is not implemented");
        }
    }
}
