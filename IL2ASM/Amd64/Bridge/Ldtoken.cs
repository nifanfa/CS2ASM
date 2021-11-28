using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldtoken)]
        public static void Ldtoken(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldtoken is not implemented");
        }
    }
}
