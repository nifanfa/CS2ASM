using CS2ASM.AMD64;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static partial class Amd64Transformation
    {
        [ILTransformation(Code.Ret)]
        public static void Ret(Context context)
        {
            if (Amd64.IsAssemblyMethod(context.def)) return;

            //Call.cs
            if (context.def.HasReturnType)
            {
                context.Pop($"rax");
                context.StackOperationCount -= 1;
            }

            int rsv = (context.def.MethodSig.Params.Count + (context.def.MethodSig.HasThis ? 1 : 0) + context.def.Body.Variables.Count) * 8;
            //dont use context.StackOperationCount -= (context.def.MethodSig.Params.Count + (context.def.MethodSig.HasThis ? 1 : 0) + context.def.Body.Variables.Count) here
            if (rsv!=0)
                context.Append($"add rsp,{rsv}");

            //dont use context.StackOperationCount-=1 here
            context.Pop($"rbp");
            context.Append($"ret");
        }
    }
}
