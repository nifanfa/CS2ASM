using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Stind_R4)]
        public static void Stind_R4(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Stind_R4 is not implemented");
        }
    }
}
