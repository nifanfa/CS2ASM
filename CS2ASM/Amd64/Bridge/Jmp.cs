using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Jmp)]
        public static void Jmp(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Jmp is not implemented");
        }
    }
}
