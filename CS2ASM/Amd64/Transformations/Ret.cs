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
                context.StackOperationCount -= 1;
            }

            int rsv = (context.def.MethodSig.Params.Count + (context.def.MethodSig.HasThis ? 1 : 0) + context.def.Body.Variables.Count) * 8;
            //dont use context.StackOperationCount -= (context.def.MethodSig.Params.Count + (context.def.MethodSig.HasThis ? 1 : 0) + context.def.Body.Variables.Count) here
            if (rsv!=0)
                context.Append($"add rsp,{rsv}");

            //dont use context.StackOperationCount-=1 here
            context.Append($"pop rbp");
            context.Append($"ret");
        }
    }
}
