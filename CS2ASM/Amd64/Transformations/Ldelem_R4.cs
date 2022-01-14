using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldelem_R4)]
        public static void Ldelem_R4(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            throw new NotImplementedException("Ldelem_R4 is not implemented");
        }
    }
}
