using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Localloc)]
        public static void Localloc(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            context.Append($"call {arch.GetCompilerMethod(Methods.Stackalloc)}");
        }
    }
}
