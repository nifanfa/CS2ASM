using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Add_Ovf)]
        public static void Add_Ovf(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Add_Ovf is not implemented");
        }
    }
}
