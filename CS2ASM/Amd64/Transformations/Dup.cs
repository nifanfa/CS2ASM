using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Dup)]
        public static void Dup(Context context)
        {
            //dangerous
            context.Append($"mov rax,[rsp]");
            context.Append($"push rax");
            context.StackOperationCount += 1;
        }
    }
}
