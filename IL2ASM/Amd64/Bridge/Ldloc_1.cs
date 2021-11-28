using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldloc_1)]
        public static void Ldloc_1(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldloc_1 is not implemented");
        }
    }
}
