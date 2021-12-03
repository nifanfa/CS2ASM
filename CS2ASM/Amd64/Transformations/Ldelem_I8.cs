using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Ldelem_I8)]
        public static void Ldelem_I8(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldelem_I8 is not implemented");
        }
    }
}
