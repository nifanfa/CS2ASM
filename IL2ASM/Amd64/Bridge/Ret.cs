using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ret)]
        public static void Ret(Arch arch, Instruction ins, MethodDef def)
        {
            if (def.Module.EntryPoint != def)
            {
                //Call.cs lines 13
                if (def.HasReturnType)
                {
                    arch.Append($"pop rax");
                    arch.Append($"mov qword [rbp+16],rax");
                }
                //recover
                arch.Append($"push qword [rbp+8]");
                arch.Append($"ret");
            }
            else
            {
                arch.Append($"jmp die");
            }
        }
    }
}
