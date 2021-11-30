using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Call)]
        public static void Call(Arch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"call {((MethodDef)ins.Operand).SafeMethodName()}");
            //Clean up
            for (int i = 0; i < ((MethodDef)ins.Operand).Parameters.Count; i++)
            {
                arch.Append($"pop rcx");
            }
            arch.Append($"mov rbp,[cache-16]");
        }
    }
}
