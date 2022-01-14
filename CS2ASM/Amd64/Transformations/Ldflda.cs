using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldflda)]
        public static void Ldflda(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            Ldfld(arch, ins, def, context);
        }
    }
}
