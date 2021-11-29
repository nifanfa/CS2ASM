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
                if (def.HasReturnType)
                {
                    arch.Append($"pop rax");
                }

                for (ulong i = 0; i < (ulong)def.Body.Variables.Count; i++)
                {
                    arch.Append($"pop rcx");
                }

                if (def.HasReturnType)
                {
                    arch.Append($"push rax");
                }

                //recover
                arch.Append($"push qword [registersave]");
                arch.Append($"ret");
            }
            else
            {
                arch.Append($"jmp die");
            }
        }
    }
}
