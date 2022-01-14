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
            context.Append($"pop rdi"); //index
            context.Append($"pop rsi"); //ptr

            context.Append($"xor rdx,rdx");
            context.Append($"mov rax,{Utility.SizeOfShallow((IType)context.operand)}");
            context.Append($"mul rdi");
            context.Append($"add rsi,rax");
            context.Append($"add rsi,{Utility.SizeOf(context.def.Module, "System.Array")}");
            context.Append($"push rsi");
        }
    }
}
