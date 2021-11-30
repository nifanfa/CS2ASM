using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Tailcall)]
        public static void Tailcall(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Tailcall is not implemented");
        }
    }
}