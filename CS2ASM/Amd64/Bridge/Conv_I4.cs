using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Conv_I4)]
        public static void Conv_I4(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Conv_I4 is not implemented");
        }
    }
}
