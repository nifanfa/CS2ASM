using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Brfalse)]
        public static void Brfalse(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Brfalse is not implemented");
        }
    }
}
