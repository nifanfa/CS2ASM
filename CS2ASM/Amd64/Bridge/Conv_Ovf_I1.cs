using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Conv_Ovf_I1)]
        public static void Conv_Ovf_I1(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Conv_Ovf_I1 is not implemented");
        }
    }
}
