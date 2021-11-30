using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldind_U1)]
        public static void Ldind_U1(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldind_U1 is not implemented");
        }
    }
}
