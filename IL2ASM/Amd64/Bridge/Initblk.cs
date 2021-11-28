using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Initblk)]
        public static void Initblk(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Initblk is not implemented");
        }
    }
}
