using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldarga)]
        public static void Ldarga(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldarga is not implemented");
        }
    }
}
