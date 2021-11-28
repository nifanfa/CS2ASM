using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Conv_Ovf_U8)]
        public static void Conv_Ovf_U8(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Conv_Ovf_U8 is not implemented");
        }
    }
}