using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Initblk)]
        public static void Initblk(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Initblk is not implemented");
        }
    }
}
