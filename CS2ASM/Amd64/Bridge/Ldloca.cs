using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldloca)]
        public static void Ldloca(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldloca is not implemented");
        }
    }
}
