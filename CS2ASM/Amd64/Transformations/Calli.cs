using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Calli)]
        public static void Calli(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            throw new NotImplementedException("Calli is not implemented");
        }
    }
}
