using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Brtrue)]
        public static void Brtrue(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Brtrue is not implemented");
        }
    }
}
