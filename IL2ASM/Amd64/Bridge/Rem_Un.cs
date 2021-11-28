using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Rem_Un)]
        public static void Rem_Un(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Rem_Un is not implemented");
        }
    }
}
