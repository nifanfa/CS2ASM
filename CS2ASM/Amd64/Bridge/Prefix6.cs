using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Prefix6)]
        public static void Prefix6(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Prefix6 is not implemented");
        }
    }
}
