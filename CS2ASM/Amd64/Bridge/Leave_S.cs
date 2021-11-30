using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Leave_S)]
        public static void Leave_S(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Leave_S is not implemented");
        }
    }
}
