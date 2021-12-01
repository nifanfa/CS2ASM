using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldsflda)]
        public static void Ldsflda(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldsflda is not implemented");
        }
    }
}
