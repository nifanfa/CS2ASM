using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldelem_I1)]
        public static void Ldelem_I1(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldelem_I1 is not implemented");
        }
    }
}
