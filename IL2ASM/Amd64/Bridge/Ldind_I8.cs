using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldind_I8)]
        public static void Ldind_I8(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldind_I8 is not implemented");
        }
    }
}
