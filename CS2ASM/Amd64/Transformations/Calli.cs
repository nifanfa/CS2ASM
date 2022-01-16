using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Calli)]
        public static void Calli(Context context)
        {
            //This is for calling c/c++ code
            if (context.numberOfVariable <= 6)
            {
                if (context.numberOfVariable >= 1)
                {
                    context.Append($"mov rdi,[rsp+{(context.numberOfVariable - 1) * 8}]");
                }
                if (context.numberOfVariable >= 2)
                {
                    context.Append($"mov rsi,[rsp+{(context.numberOfVariable - 2) * 8}]");
                }
                if (context.numberOfVariable >= 3)
                {
                    context.Append($"mov rdx,[rsp+{(context.numberOfVariable - 3) * 8}]");
                }
                if (context.numberOfVariable >= 4)
                {
                    context.Append($"mov rcx,[rsp+{(context.numberOfVariable - 4) * 8}]");
                }
                if (context.numberOfVariable >= 5)
                {
                    context.Append($"mov r8,[rsp+{(context.numberOfVariable - 5) * 8}]");
                }
                if (context.numberOfVariable >= 6)
                {
                    context.Append($"mov r9,[rsp+{(context.numberOfVariable - 6) * 8}]");
                }
            }
            else 
            {
                throw new ArgumentOutOfRangeException("Too much argument");
            }
            context.Append($"add rsp,{context.numberOfVariable * 8}");
            context.Append("pop rax");
            context.Append("call rax");
        }
    }
}
