using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Stind_I2)]
        public static void Stind_I2(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Stind_I2 is not implemented");
        }
    }
}
