using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Refanyval)]
        public static void Refanyval(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Refanyval is not implemented");
        }
    }
}