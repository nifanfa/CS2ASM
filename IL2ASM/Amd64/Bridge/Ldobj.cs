using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldobj)]
        public static void Ldobj(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldobj is not implemented");
        }
    }
}
