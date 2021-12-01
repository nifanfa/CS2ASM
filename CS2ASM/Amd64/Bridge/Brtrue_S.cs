using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Brtrue_S)]
        public static void Brtrue_S(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Brtrue_S is not implemented");
        }
    }
}
