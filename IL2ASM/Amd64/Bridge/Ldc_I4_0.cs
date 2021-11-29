using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldc_I4_0)]
        public static void Ldc_I4_0(Arch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"push {ValueReader.Ldc(ins)}");
        }
    }
}
