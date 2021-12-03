using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Ldelem_I4)]
        public static void Ldelem_I4(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldelem_I4 is not implemented");
        }
    }
}
