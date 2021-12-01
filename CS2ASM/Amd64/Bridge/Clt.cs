using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Clt)]
        public static void Clt(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Clt is not implemented");
        }
    }
}
