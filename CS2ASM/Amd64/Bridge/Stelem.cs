using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Stelem)]
        public static void Stelem(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Stelem is not implemented");
        }
    }
}
