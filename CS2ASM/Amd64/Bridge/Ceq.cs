using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ceq)]
        public static void Ceq(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ceq is not implemented");
        }
    }
}
