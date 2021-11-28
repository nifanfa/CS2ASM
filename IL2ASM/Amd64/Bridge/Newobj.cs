using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Newobj)]
        public static void Newobj(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Newobj is not implemented");
        }
    }
}
