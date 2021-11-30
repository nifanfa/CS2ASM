using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ble)]
        public static void Ble(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ble is not implemented");
        }
    }
}
