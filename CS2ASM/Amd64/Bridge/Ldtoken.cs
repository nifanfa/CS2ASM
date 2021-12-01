using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldtoken)]
        public static void Ldtoken(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldtoken is not implemented");
        }
    }
}
