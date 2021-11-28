using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Conv_Ovf_U2_Un)]
        public static void Conv_Ovf_U2_Un(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Conv_Ovf_U2_Un is not implemented");
        }
    }
}