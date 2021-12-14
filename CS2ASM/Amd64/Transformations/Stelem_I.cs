using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Stelem_I)]
        public static void Stelem_I(BaseArch arch, Instruction ins, MethodDef def)
        {
            Stelem(arch, ins, def);
        }
    }
}
