using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldelema)]
        public static void Ldelema(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldelema is not implemented");
        }
    }
}
