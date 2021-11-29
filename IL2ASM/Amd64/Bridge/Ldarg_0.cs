using System;
using System.Diagnostics;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldarg_0)]
        public static void Ldarg_0(Arch arch, Instruction ins, MethodDef def)
        {
            //throw new NotImplementedException("Ldarg_0 is not implemented");
            arch.Append($"push qword [rbp+{16 + (ValueReader.Ldarg(ins) * 8)}]");
        }
    }
}
