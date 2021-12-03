using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Ldelem)]
        public static void Ldelem(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldelem is not implemented");
        }
    }
}
