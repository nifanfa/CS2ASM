using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Readonly)]
        public static void Readonly(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Readonly is not implemented");
        }
    }
}
