using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Initobj)]
        public static void Initobj(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Initobj is not implemented");
        }
    }
}
