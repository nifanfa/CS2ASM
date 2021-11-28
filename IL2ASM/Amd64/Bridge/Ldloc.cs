using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldloc)]
        public static void Ldloc(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldloc is not implemented");
        }
    }
}
