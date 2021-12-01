using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ceq)]
        public static void Ceq(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"pop rdx");
            arch.Append($"pop rax");
            arch.Append($"cmp rax,rdx");
            arch.Append($"je $+6");
            arch.Append($"push 0");
            arch.Append($"jmp $+4");
            arch.Append($"push 1");
        }
    }
}
