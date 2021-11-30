using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Bge_Un_S)]
        public static void Bge_Un_S(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Bge_Un_S is not implemented");
        }
    }
}
