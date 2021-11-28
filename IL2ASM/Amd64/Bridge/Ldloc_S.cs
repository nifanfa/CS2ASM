using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldloc_S)]
        public static void Ldloc_S(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldloc_S is not implemented");
        }
    }
}
