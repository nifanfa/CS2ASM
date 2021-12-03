using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Ldlen)]
        public static void Ldlen(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldlen is not implemented");
        }
    }
}
