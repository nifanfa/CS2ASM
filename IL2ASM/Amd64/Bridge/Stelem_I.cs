using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Stelem_I)]
        public static void Stelem_I(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Stelem_I is not implemented");
        }
    }
}
