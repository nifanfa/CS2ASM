using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Bgt)]
        public static void Bgt(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            throw new NotImplementedException("Bgt is not implemented");
        }
    }
}
