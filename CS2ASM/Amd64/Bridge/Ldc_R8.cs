using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldc_R8)]
        public static void Ldc_R8(Arch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"push {OperandParser.Ldc(ins)}");
        }
    }
}
