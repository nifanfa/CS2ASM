using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldtoken)]
        public static void Ldtoken(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            throw new NotImplementedException("Ldtoken is not implemented");
        }
    }
}
