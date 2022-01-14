using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldelem_U4)]
        public static void Ldelem_U4(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            Ldelem(arch, ins, def, context);
        }
    }
}
