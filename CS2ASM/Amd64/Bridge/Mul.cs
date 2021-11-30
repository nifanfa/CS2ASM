using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Mul)]
        public static void Mul(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Mul is not implemented");
        }
    }
}
