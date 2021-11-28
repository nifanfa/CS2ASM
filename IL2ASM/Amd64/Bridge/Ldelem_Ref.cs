using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldelem_Ref)]
        public static void Ldelem_Ref(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldelem_Ref is not implemented");
        }
    }
}
