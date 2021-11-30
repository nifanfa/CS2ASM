using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Conv_U2)]
        public static void Conv_U2(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Conv_U2 is not implemented");
        }
    }
}
