using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldloca_S)]
        public static void Ldloca_S(BaseArch arch, Instruction ins, MethodDef def)
        {
            Ldloc_S(arch, ins, def);
        }
    }
}
