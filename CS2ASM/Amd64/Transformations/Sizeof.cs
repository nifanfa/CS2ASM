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
            if (context.operand is TypeSpec)
                context.Append($"mov rax,{Utility.SizeOfShallow(((TypeSpec)context.operand).ScopeType)}");
            else
            {
                context.Append($"mov rax,{Utility.SizeOfOrIndex((TypeDef)context.operand, null)}");
            }

            context.Push($"rax");
            context.StackOperationCount += 1;
        }
    }
}
