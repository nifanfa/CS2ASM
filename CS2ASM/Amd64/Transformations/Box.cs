using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Box)]
        public static void Box(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Box is not implemented");
        }
    }
}
