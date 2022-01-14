using CS2ASM.AMD64;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ret)]
        public static void Ret(Context context)
        {
            if (Amd64.IsAssemblyMethod(context.def)) return;

            //Call.cs
            if (context.def.HasReturnType)
            {
                context.Append($"pop rax");
            }
            context.Append($"pop rbx");

            //Clean up local variables
            context.Append($"add rsp,{context.def.Body.Variables.Count * 8}");

            context.Append($"mov rbp,rbx");

            context.Append($"pop rbx");

            //Clean up arguments
            context.Append($"add rsp,{context.def.Parameters.Count * 8}");

            if (context.def.HasReturnType)
            {
                context.Append($"push rax");
            }

            context.Append($"push rbx");

            context.Append($"ret");
        }
    }
}
