using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Stloc)]
        public static void Stloc(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Stloc is not implemented");
        }
    }
}
