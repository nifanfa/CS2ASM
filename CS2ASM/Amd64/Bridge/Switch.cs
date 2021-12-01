using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Switch)]
        public static void Switch(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Switch is not implemented");
        }
    }
}
