using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ckfinite)]
        public static void Ckfinite(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ckfinite is not implemented");
        }
    }
}
