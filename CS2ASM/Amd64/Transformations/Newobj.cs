using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Newobj)]
        public static void Newobj(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"call ConsoleApp1_Program_malloc");
            arch.Append($"pop rbp");
            arch.Append($"push rax");
            arch.Append($"call {Amd64.SafeMethodName((MethodDef)ins.Operand)}");
            arch.Append($"pop rbp");
        }
    }
}
