using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Stobj)]
        public static void Stobj(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            throw new NotImplementedException("Stobj is not implemented");
        }
    }
}
