using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Mkrefany)]
        public static void Mkrefany(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Mkrefany is not implemented");
        }
    }
}
