using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Rem)]
        public static void Rem(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            context.Append($"xor rdx,rdx");
            context.Append($"pop rbx");
            context.Append($"pop rax");
            context.Append($"idiv rbx");
            context.Append($"push rdx");
        }
    }
}
