using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.No)]
        public static void No(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("No is not implemented");
        }
    }
}
