using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Cgt)]
        public static void Cgt(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Cgt is not implemented");
        }
    }
}
