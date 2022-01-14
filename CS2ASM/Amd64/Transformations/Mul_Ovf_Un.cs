using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Mul_Ovf_Un)]
        public static void Mul_Ovf_Un(Context context)
        {
            //TO-DO Overflow Exception
            context.Append($"xor rdx,rdx");
            context.Append($"pop rbx");
            context.Append($"pop rax");
            context.Append($"mul rbx");
            context.Append($"push rax");
        }
    }
}
