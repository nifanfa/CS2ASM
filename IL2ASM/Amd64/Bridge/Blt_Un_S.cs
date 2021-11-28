using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Blt_Un_S)]
        public static void Blt_Un_S(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Blt_Un_S is not implemented");
        }
    }
}
