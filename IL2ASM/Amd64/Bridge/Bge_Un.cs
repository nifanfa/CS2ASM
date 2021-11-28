using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Bge_Un)]
        public static void Bge_Un(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Bge_Un is not implemented");
        }
    }
}
