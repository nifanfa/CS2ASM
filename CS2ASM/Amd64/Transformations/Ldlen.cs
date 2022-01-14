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
            context.Append($"pop rsi");
            context.Append($"add rsi,{Utility.SizeOf(context.def.Module, "System.Array")}");
            context.Append($"push rsi");
        }
    }
}
