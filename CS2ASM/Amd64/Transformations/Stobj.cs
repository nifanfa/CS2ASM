using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Stobj)]
        public static void Stobj(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Stobj is not implemented");
        }
    }
}
