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
            arch.Append($"push {OperandReader.Ldc(ins)}");
        }
    }
}
