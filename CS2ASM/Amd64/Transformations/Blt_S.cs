using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Blt_S)]
        public static void Blt_S(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            throw new NotImplementedException("Blt_S is not implemented");
        }
    }
}
