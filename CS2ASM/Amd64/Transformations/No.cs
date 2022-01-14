using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.No)]
        public static void No(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            throw new NotImplementedException("No is not implemented");
        }
    }
}
