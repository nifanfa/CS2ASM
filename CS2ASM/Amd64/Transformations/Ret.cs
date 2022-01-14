using CS2ASM.AMD64;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ret)]
        public static void Ret(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            if (Amd64.IsEmptyMethod(def)) return;

            //Call.cs
            if (def.HasReturnType)
            {
                context.Append($"pop rax");
            }
            context.Append($"pop rbx");

            //Clean up local variables
            context.Append($"add rsp,{def.Body.Variables.Count * 8}");

            context.Append($"mov rbp,rbx");

            context.Append($"pop rbx");

            //Clean up arguments
            context.Append($"add rsp,{def.Parameters.Count * 8}");

            if (def.HasReturnType)
            {
                context.Append($"push rax");
            }

            context.Append($"push rbx");

            context.Append($"ret");
        }
    }
}
