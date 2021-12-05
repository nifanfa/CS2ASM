using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Unbox)]
        public static void Unbox(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Unbox is not implemented");
        }
    }
}
