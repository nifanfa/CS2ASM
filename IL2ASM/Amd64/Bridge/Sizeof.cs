using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Sizeof)]
        public static void Sizeof(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Sizeof is not implemented");
        }
    }
}
