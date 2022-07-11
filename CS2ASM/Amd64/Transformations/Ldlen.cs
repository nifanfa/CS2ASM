using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldlen)]
        public static void Ldlen(Context context)
        {
            context.Pop($"rsi");
            context.StackOperationCount -= 1;
            context.Append($"add rsi,{Utility.SizeOf(context.def.Module, "System.Array")}");
            context.Push($"rsi");
            context.StackOperationCount += 1;
        }
    }
}
