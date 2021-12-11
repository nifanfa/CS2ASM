using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Mul_Ovf_Un)]
        public static void Mul_Ovf_Un(BaseArch arch, Instruction ins, MethodDef def)
        {
            //TO-DO Overflow Exception
            arch.Append($"xor rdx,rdx");
            arch.Append($"pop rbx");
            arch.Append($"pop rax");
            arch.Append($"mul rbx");
            arch.Append($"push rax");
        }
    }
}
