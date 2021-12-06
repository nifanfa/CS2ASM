using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ret)]
        public static void Ret(BaseArch arch, Instruction ins, MethodDef def)
        {
            if (def.Module.EntryPoint != def)
            {
                //Call.cs
                if (def.HasReturnType)
                {
                    arch.Append($"pop rax");
                }

                if (def.Body.Variables.Count != 0)
                    arch.Append($"add rsp,{def.Body.Variables.Count * 8}");

                arch.Append($"leave");
                arch.Append($"ret");
            }
            else
            {
                arch.Append($"jmp die");
            }
        }
    }
}
