using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Newarr)]
        public static void Newarr(Context context)
        {
            context.Append($"mov rax,{Utility.SizeOfShallow((IType)context.operand)}");
            context.Append("push rax");
            context.StackOperationCount += 1;
            context.Append($"pop rsi");
            context.Append($"pop rdi");
            context.StackOperationCount -= 2;
            context.Append($"call {context.arch.GetCompilerMethod(Methods.ArrayCtor)}");
            context.Append($"push rax");
            context.StackOperationCount += 1;
        }
    }
}
