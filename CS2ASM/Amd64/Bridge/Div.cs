using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Div)]
        public static void Div(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Div is not implemented");
        }
    }
}
