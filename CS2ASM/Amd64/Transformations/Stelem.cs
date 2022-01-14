using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Stelem)]
        public static void Stelem(Context context)
        {
            context.Append($"pop rbx"); //value
            context.Append($"pop rdi"); //index
            context.Append($"pop rsi"); //ptr
            context.Append($"xor rdx,rdx");
            context.Append($"mov rax,8");
            context.Append($"mul rdi");
            context.Append($"add rsi,rax");
            context.Append($"add rsi,{Utility.SizeOf(context.def.Module, "System.Array")}");
            context.Append($"mov qword [rsi],rbx");
        }
    }
}
