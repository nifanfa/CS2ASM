using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Stobj)]
        public static void Stobj(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Stobj is not implemented");
        }
    }
}
