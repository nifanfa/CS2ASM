using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Bge_S)]
        public static void Bge_S(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Bge_S is not implemented");
        }
    }
}
