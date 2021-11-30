using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldelem_U4)]
        public static void Ldelem_U4(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldelem_U4 is not implemented");
        }
    }
}
