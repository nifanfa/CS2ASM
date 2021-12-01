using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldnull)]
        public static void Ldnull(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldnull is not implemented");
        }
    }
}
