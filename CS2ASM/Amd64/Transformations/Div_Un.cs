using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Div_Un)]
        public static void Div_Un(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"xor rdx,rdx");
            arch.Append($"pop r8");
            arch.Append($"pop rax");
            arch.Append($"div r8");
            arch.Append($"push rax");
        }
    }
}
