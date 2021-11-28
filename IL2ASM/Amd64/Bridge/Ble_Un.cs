using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ble_Un)]
        public static void Ble_Un(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ble_Un is not implemented");
        }
    }
}
