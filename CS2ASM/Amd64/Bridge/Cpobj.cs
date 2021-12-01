using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Cpobj)]
        public static void Cpobj(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Cpobj is not implemented");
        }
    }
}
