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
            context.Append($"mov rdi,[rsp+8]");
            context.Append($"mov rsi,[rsp]");
            context.Append($"call {context.arch.GetCompilerMethod(Methods.ArrayCtor)}");
        }
    }
}
