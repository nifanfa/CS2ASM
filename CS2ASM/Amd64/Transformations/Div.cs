using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Div)]
        public static void Div(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"pop rbx");
            arch.Append($"pop rax");
            arch.Append($"div rbx");
            arch.Append($"push rax");
        }
    }
}
