using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Div)]
        public static void Div(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"xor rdx,rdx");
            arch.Append($"pop rbx");
            arch.Append($"pop rax");
            arch.Append($"idiv rbx");
            arch.Append($"push rax");
        }
    }
}
