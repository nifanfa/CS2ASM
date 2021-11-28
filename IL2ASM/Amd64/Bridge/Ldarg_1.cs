using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldarg_1)]
        public static void Ldarg_1(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldarg_1 is not implemented");
        }
    }
}
