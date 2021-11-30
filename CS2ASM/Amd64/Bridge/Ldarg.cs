using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldarg)]
        public static void Ldarg(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldarg is not implemented");
        }
    }
}
