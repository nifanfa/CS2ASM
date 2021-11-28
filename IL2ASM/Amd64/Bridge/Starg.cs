using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Starg)]
        public static void Starg(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Starg is not implemented");
        }
    }
}
