using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Prefix7)]
        public static void Prefix7(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Prefix7 is not implemented");
        }
    }
}
