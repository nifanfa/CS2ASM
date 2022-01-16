using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Localloc)]
        public static void Localloc(Context context)
        {
            context.Append($"pop rdi");
            context.Append($"call {context.arch.GetCompilerMethod(Methods.Stackalloc)}");
            context.Append($"push rax");
        }
    }
}
