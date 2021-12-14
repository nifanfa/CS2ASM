using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldelem_I)]
        public static void Ldelem_I(BaseArch arch, Instruction ins, MethodDef def)
        {
            Ldelem(arch, ins, def);
        }
    }
}
