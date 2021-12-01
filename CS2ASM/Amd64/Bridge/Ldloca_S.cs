using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldloca_S)]
        public static void Ldloca_S(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldloca_S is not implemented");
        }
    }
}
