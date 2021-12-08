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
            arch.Append($"pop rbx");
            arch.Append($"pop rax");
            arch.Append($"div rbx");
            arch.Append($"push rax");
        }
    }
}
