using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ble_Un_S)]
        public static void Ble_Un_S(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ble_Un_S is not implemented");
        }
    }
}
