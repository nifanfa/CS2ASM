using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldelema)]
        public static void Ldelema(Context context)
        {
            context.Pop($"rdi"); //index
            context.Pop($"rsi"); //ptr
            context.StackOperationCount -= 2;

            context.Append($"xor rdx,rdx");
            context.Append($"mov rax,{Utility.SizeOfShallow((IType)context.operand)}");
            context.Append($"mul rdi");
            context.Append($"add rsi,rax");
            context.Append($"add rsi,{Utility.SizeOf(context.def.Module, "System.Array")}");
            context.Push($"rsi");
            context.StackOperationCount += 1;
        }
    }
}
