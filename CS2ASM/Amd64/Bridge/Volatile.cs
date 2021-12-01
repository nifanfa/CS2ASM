using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Volatile)]
        public static void Volatile(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Volatile is not implemented");
        }
    }
}
