using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldloc_2)]
        public static void Ldloc_2(Arch arch, Instruction ins, MethodDef def)
        {
            ulong Index = ValueReader.Ldloc(ins) + 1;
            arch.Append($"push qword [rbp-{Index * 8}]");
        }
    }
}
