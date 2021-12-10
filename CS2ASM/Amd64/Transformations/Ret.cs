using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ret)]
        public static void Ret(BaseArch arch, Instruction ins, MethodDef def)
        {
            //Call.cs
            if (def.HasReturnType)
            {
                arch.Append($"pop rax");
            }
            arch.Append($"pop r8");

            //Clean up local variables
            arch.Append($"add rsp,{def.Body.Variables.Count * 8}");

            arch.Append($"mov rbp,r8");

            arch.Append($"pop r8");

            //Clean up arguments
            arch.Append($"add rsp,{def.Parameters.Count * 8}");

            if (def.HasReturnType)
            {
                arch.Append($"push rax");
            }

            arch.Append($"push r8");

            arch.Append($"ret");
        }
    }
}
