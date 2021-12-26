using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Sizeof)]
        public static void Sizeof(BaseArch arch, Instruction ins, MethodDef def)
        {
            if (ins.Operand is TypeSpec)
                arch.Append($"mov rax,{Utility.SizeOfShallow(((TypeSpec)ins.Operand).ScopeType)}");
            else
            {
                arch.Append($"mov rax,{Utility.SizeOfOrIndex((TypeDef)ins.Operand, null)}");
            }

            arch.Append($"push rax");
        }
    }
}
