using CS2ASM.AMD64;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ret)]
        public static void Ret(BaseArch arch, Instruction ins, MethodDef def)
        {
            if (Amd64.IsEmptyMethod(def)) return;

            //Call.cs
            if (def.HasReturnType)
            {
                arch.Append($"pop rax");
            }
            arch.Append($"pop rbx");

            //Clean up local variables
            arch.Append($"add rsp,{def.Body.Variables.Count * 8}");

            arch.Append($"mov rbp,rbx");

            arch.Append($"pop rbx");

            //Clean up arguments
            arch.Append($"add rsp,{def.Parameters.Count * 8}");

            if (def.HasReturnType)
            {
                arch.Append($"push rax");
            }

            arch.Append($"push rbx");

            arch.Append($"ret");
        }
    }
}
