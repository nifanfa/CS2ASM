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
            if (!def.Body.Instructions[def.Body.Instructions.IndexOf(ins) + 1].IsStloc())
                throw new Exception();
            arch.Append($"push 4096");
            arch.Append($"call System.Runtime.CompilerServices.Unsafe.Stackalloc");
            arch.Append($"pop rax");
            arch.Append($"push rax");
            arch.Append($"push rax");
            Stloc(arch, def.Body.Instructions[def.Body.Instructions.IndexOf(ins) + 1], def);
            arch.Append($"call {Util.SafeMethodName((MethodDef)ins.Operand)}");
            arch.Append($"push rax");
            arch.SkipNextInstruction();
        }
    }
}
