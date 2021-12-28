using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Stelem_Ref)]
        public static void Stelem_Ref(BaseArch arch, Instruction ins, MethodDef def)
        {
            Stelem(arch, ins, def);
        }
    }
}
