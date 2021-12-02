using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ret)]
        public static void Ret(BaseArch arch, Instruction ins, MethodDef def)
        {
            if (def.Module.EntryPoint != def)
            {
                //Call.cs
                if (def.HasReturnType)
                {
                    arch.Append($"pop rax");
                }
                
                arch.Append($"add rsp,{def.Body.Variables.Count * 8}");

                //recover
                //arch.Append($"push qword [cache-8]");
                arch.Append($"ret");
            }
            else
            {
                arch.Append($"jmp die");
            }
        }
    }
}
