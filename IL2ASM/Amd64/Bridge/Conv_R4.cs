using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Conv_R4)]
        public static void Conv_R4(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Conv_R4 is not implemented");
        }
    }
}
