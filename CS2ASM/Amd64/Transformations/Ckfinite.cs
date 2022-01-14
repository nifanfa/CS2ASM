using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ckfinite)]
        public static void Ckfinite(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            throw new NotImplementedException("Ckfinite is not implemented");
        }
    }
}
