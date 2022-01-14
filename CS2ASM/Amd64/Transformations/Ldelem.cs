using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldelem)]
        public static void Ldelem(Context context)
        {
            context.Append($"pop rdi"); //index
            context.Append($"pop rsi"); //ptr

            context.Append($"xor rdx,rdx");
            context.Append($"mov rax,8");
            context.Append($"mul rdi");
            context.Append($"add rsi,rax");
            context.Append($"add rsi,{Utility.SizeOf(context.def.Module,"System.Array")}");
            context.Append($"mov qword rax,[rsi]");
            context.Append($"push rax");
        }
    }
}
