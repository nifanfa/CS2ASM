using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Refanytype)]
        public static void Refanytype(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Refanytype is not implemented");
        }
    }
}
