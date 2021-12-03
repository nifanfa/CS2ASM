using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Ldind_U2)]
        public static void Ldind_U2(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"pop rax");
            arch.Append($"push qword [rax]");
        }
    }
}
