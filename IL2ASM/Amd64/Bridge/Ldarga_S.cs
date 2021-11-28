using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldarga_S)]
        public static void Ldarga_S(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldarga_S is not implemented");
        }
    }
}
