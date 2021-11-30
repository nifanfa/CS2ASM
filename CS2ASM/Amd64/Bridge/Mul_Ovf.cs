using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Mul_Ovf)]
        public static void Mul_Ovf(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Mul_Ovf is not implemented");
        }
    }
}
