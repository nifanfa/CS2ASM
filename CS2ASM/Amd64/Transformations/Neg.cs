using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Neg)]
        public static void Neg(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            context.Append("pop rbx");
            context.Append("xor rdx,rdx");
            context.Append("neg rbx");
            context.Append("push rbx");
        }
    }
}
