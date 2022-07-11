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
            DoLdelem(context, 8);
        }

        private static void DoLdelem(Context context,int size)
        {
            context.Pop($"rdi"); //index
            context.Pop($"rsi"); //ptr
            context.StackOperationCount -= 2;

            context.Append($"xor rdx,rdx");
            context.Append($"mov rax,{size}");
            context.Append($"mul rdi");
            context.Append($"add rsi,rax");
            context.Append($"add rsi,{Utility.SizeOf(context.def.Module, "System.Array")}");
            context.Append($"xor rax,rax");
            switch (size)
            {
                case 1:
                    context.Append($"mov al,[rsi]");
                    break;
                case 2:
                    context.Append($"mov ax,[rsi]");
                    break;
                case 4:
                    context.Append($"mov eax,[rsi]");
                    break;
                default:
                    context.Append($"mov rax,[rsi]");
                    break;
            }
            context.Push($"rax");
            context.StackOperationCount += 1;
        }
    }
}
