using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Div_Un)]
        public static void Div_Un(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Div_Un is not implemented");
        }
    }
}
