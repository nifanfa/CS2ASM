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
            DoStelem(context, 8);
        }

        private static void DoStelem(Context context, int size)
        {
            context.Append($"pop rbx"); //value
            context.Append($"pop rdi"); //index
            context.Append($"pop rsi"); //ptr
            context.Append($"xor rdx,rdx");
            context.Append($"mov rax,{size}");
            context.Append($"mul rdi");
            context.Append($"add rsi,rax");
            context.Append($"add rsi,{Utility.SizeOf(context.def.Module, "System.Array")}");
            switch (size) 
            {
                case 1:
                    context.Append($"mov byte [rsi],bl");
                    break;
                case 2:
                    context.Append($"mov word [rsi],bx");
                    break;
                case 4:
                    context.Append($"mov dword [rsi],ebx");
                    break;
                default:
                    context.Append($"mov qword [rsi],rbx");
                    break;
            }
        }
    }
}
