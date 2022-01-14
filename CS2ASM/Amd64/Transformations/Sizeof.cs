using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Sizeof)]
        public static void Sizeof(Context context)
        {
            if (context.ins.Operand is TypeSpec)
                context.Append($"mov rax,{Utility.SizeOfShallow(((TypeSpec)context.ins.Operand).ScopeType)}");
            else
            {
                context.Append($"mov rax,{Utility.SizeOfOrIndex((TypeDef)context.ins.Operand, null)}");
            }

            context.Append($"push rax");
        }
    }
}
