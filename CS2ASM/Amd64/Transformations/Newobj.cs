using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Newobj)]
        public static void Newobj(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"push 4096");
            arch.Append($"call System.Runtime.CompilerServices.Unsafe.Stackalloc");
            arch.Append($"pop rax");
            arch.Append($"push rax");
            arch.Append($"push rax");
            arch.Append($"call {Util.SafeMethodName((MethodDef)ins.Operand)}");
        }
    }
}
