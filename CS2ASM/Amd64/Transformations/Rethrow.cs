using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Rethrow)]
        public static void Rethrow(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Rethrow is not implemented");
        }
    }
}