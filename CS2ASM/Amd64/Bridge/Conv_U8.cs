using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Conv_U8)]
        public static void Conv_U8(BaseArch arch, Instruction ins, MethodDef def)
        {
        }
    }
}
