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
            arch.Append($"push 0 ;false");
            arch.Append($"cmp rax,rdx");
            arch.Append($"jne $+10"); //$+2+InstructionBytes
            arch.Append($"mov qword [rsp+8],1");
        }
    }
}
