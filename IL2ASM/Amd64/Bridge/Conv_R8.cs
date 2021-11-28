using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Conv_R8)]
        public static void Conv_R8(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Conv_R8 is not implemented");
        }
    }
}
