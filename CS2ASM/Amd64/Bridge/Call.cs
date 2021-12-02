using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Call)]
        public static void Call(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"call {Amd64.SafeMethodName(((MethodDef)ins.Operand))}");

            arch.Append($"pop rbp"); //Recover rbp register
            //Clean up arguments
            arch.Append($"add rsp,{((MethodDef)ins.Operand).Parameters.Count * 8}");

            //Ret.cs
            if (def.HasReturnType)
            {
                arch.Append($"push rax");
            }
        }
    }
}
