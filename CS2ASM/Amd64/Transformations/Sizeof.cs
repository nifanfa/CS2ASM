using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Sizeof)]
        public static void Sizeof(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            if (ins.Operand is TypeSpec)
                context.Append($"mov rax,{Utility.SizeOfShallow(((TypeSpec)ins.Operand).ScopeType)}");
            else
            {
                context.Append($"mov rax,{Utility.SizeOfOrIndex((TypeDef)ins.Operand, null)}");
            }

            context.Append($"push rax");
        }
    }
}
