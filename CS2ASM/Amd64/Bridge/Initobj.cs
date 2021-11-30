using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Initobj)]
        public static void Initobj(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Initobj is not implemented");
        }
    }
}
