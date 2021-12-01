using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Not)]
        public static void Not(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Not is not implemented");
        }
    }
}
