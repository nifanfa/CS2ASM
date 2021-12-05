using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Leave)]
        public static void Leave(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Leave is not implemented");
        }
    }
}
