using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Stelem_R4)]
        public static void Stelem_R4(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Stelem_R4 is not implemented");
        }
    }
}
