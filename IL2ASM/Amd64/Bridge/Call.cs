using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Diagnostics;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Call)]
        public static void Call(Arch arch, Instruction ins, MethodDef def)
        {
            for(int i =0;i< ((MethodDef)ins.Operand).Parameters.Count; i++) 
            {
                arch.Append($"pop rcx");
                arch.Append($"mov qword [rbp+{16 + (i * 8)}],rcx");
            }
            arch.Append($"call {((MethodDef)ins.Operand).SafeMethodName()}");
        }
    }
}
