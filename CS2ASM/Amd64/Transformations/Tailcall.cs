using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Tailcall)]
        public static void Tailcall(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Tailcall is not implemented");
        }
    }
}
