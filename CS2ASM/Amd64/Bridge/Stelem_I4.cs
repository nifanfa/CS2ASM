using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Stelem_I4)]
        public static void Stelem_I4(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Stelem_I4 is not implemented");
        }
    }
}
