using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Prefix5)]
        public static void Prefix5(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Prefix5 is not implemented");
        }
    }
}
