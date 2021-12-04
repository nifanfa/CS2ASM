using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldloca)]
        public static void Ldloca(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldloca is not implemented");
        }
    }
}
