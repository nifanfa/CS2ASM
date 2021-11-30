using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Stloc_0)]
        public static void Stloc_0(Arch arch, Instruction ins, MethodDef def)
        {
            ulong Index = OperandParser.Stloc(ins) + 1;
            arch.Append($"pop rax");
            arch.Append($"mov [rbp-{Index * 8}],rax");
        }
    }
}
