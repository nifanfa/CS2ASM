using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Callvirt)]
        public static void Callvirt(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Callvirt is not implemented");
        }
    }
}
