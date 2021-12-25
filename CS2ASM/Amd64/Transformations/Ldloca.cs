using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldloca)]
        public static void Ldloca(BaseArch arch, Instruction ins, MethodDef def)
        {
            Ldloc(arch, ins, def);
        }
    }
}
