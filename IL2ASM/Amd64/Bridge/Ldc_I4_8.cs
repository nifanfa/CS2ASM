using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldc_I4_8)]
        public static void Ldc_I4_8(Arch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"push {ValueReader.Ldc(ins)}");
        }
    }
}
