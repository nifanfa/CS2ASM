using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldflda)]
        public static void Ldflda(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldflda is not implemented");
        }
    }
}
