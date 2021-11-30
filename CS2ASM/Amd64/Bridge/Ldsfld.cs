using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldsfld)]
        public static void Ldsfld(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldsfld is not implemented");
        }
    }
}
