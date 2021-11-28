using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Brfalse_S)]
        public static void Brfalse_S(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Brfalse_S is not implemented");
        }
    }
}
