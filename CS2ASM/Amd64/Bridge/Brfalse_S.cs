using System;
using System.Diagnostics;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Brfalse_S)]
        public static void Brfalse_S(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"pop rax");
            arch.Append($"cmp rax,0");
            arch.Append($"je {Amd64.BrLabelName(ins, def)}");
        }
    }
}
