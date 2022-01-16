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
            context.Append($"add rsp,{((ulong)context.def.MethodSig.Params.Count + (ulong)(context.def.MethodSig.HasThis ? 1 : 0) + (ulong)context.def.Body.Variables.Count) * 8}");
            context.Append($"pop rbp");
            context.Append($"pop rbx");
            if (context.def.HasReturnType)
            {
                context.Append($"push rax");
            }
            context.Append($"push rbx");
            context.Append($"ret");
        }
    }
}
