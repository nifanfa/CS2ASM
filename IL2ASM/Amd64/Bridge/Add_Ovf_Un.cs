using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Add_Ovf_Un)]
        public static void Add_Ovf_Un(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Add_Ovf_Un is not implemented");
        }
    }
}