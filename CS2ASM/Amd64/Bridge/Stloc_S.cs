using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Stloc_S)]
        public static void Stloc_S(Arch arch, Instruction ins, MethodDef def)
        {
            ulong Index = OperandReader.Stloc(ins) + 1;
            arch.Append($"pop rax");
            arch.Append($"mov [rbp-{Index * 8}],rax");
        }
    }
}