using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.And)]
        public static void And(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("And is not implemented");
        }
    }
}
