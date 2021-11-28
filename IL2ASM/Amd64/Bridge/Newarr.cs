using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Newarr)]
        public static void Newarr(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Newarr is not implemented");
        }
    }
}
