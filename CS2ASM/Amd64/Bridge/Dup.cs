using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Dup)]
        public static void Dup(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Dup is not implemented");
        }
    }
}
