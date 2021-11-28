using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Unbox_Any)]
        public static void Unbox_Any(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Unbox_Any is not implemented");
        }
    }
}
