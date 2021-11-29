using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Stloc_2)]
        public static void Stloc_2(Arch arch, Instruction ins, MethodDef def)
        {
            ulong Index = ValueReader.Stloc(ins) + 1;
            arch.Append($"pop rax");
            arch.Append($"mov [rbp-{Index * 8}],rax");
        }
    }
}
