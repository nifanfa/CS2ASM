using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Bne_Un_S)]
        public static void Bne_Un_S(BaseArch arch, Instruction ins, MethodDef def)
        {
            Bne_Un(arch, ins, def);
        }
    }
}
