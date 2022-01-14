using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Endfinally)]
        public static void Endfinally(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            throw new NotImplementedException("Endfinally is not implemented");
        }
    }
}
