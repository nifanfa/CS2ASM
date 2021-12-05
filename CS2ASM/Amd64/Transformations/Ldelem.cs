using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldelem)]
        public static void Ldelem(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldelem is not implemented");
        }
    }
}
