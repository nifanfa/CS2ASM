using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldstr)]
        public static void Ldstr(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldstr is not implemented");
        }
    }
}
