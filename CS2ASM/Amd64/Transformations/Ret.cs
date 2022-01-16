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

            ulong rsv = ((ulong)context.def.MethodSig.Params.Count + (ulong)(context.def.MethodSig.HasThis ? 1 : 0) + (ulong)context.def.Body.Variables.Count) * 8;
            if(rsv!=0)
                context.Append($"add rsp,{rsv}");

            context.Append($"pop rbp");
            context.Append($"ret");
        }
    }
}
