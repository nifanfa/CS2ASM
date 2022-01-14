using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Cpobj)]
        public static void Cpobj(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            throw new NotImplementedException("Cpobj is not implemented");
        }
    }
}
