using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Stind_Ref)]
        public static void Stind_Ref(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Stind_Ref is not implemented");
        }
    }
}
