using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Stelem_I1)]
        public static void Stelem_I1(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Stelem_I1 is not implemented");
        }
    }
}
