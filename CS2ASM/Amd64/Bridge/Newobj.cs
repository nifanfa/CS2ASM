using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Newobj)]
        public static void Newobj(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Newobj is not implemented");
        }
    }
}
