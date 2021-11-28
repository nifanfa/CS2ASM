using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldind_I1)]
        public static void Ldind_I1(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldind_I1 is not implemented");
        }
    }
}
