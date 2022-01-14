using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldelema)]
        public static void Ldelema(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            Ldelem(arch, ins, def, context);
        }
    }
}
