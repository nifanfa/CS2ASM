using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Shr_Un)]
        public static void Shr_Un(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Shr_Un is not implemented");
        }
    }
}
