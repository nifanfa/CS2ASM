using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldloc_S)]
        public static void Ldloc_S(BaseArch arch, Instruction ins, MethodDef def)
        {
            ulong Index = OperandParser.Ldloc(ins) + 1;
            arch.Append($"push qword [rbp-{Index * 8}]");
        }
    }
}
