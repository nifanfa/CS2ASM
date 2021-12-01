using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ckfinite)]
        public static void Ckfinite(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ckfinite is not implemented");
        }
    }
}
