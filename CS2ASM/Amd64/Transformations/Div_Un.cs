using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Div_Un)]
        public static void Div_Un(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Div_Un is not implemented");
        }
    }
}
