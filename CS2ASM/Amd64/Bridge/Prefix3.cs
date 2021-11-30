using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Prefix3)]
        public static void Prefix3(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Prefix3 is not implemented");
        }
    }
}
