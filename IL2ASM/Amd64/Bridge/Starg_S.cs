using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Starg_S)]
        public static void Starg_S(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Starg_S is not implemented");
        }
    }
}
