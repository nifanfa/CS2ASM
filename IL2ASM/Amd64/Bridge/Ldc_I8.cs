using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldc_I8)]
        public static void Ldc_I8(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldc_I8 is not implemented");
        }
    }
}
