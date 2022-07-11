using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldind_I8)]
        public static void Ldind_I8(Context context)
        {
            //This is for "this" keyword
            if (context.prevInstruction.IsLdarg())
            {
                var p = context.def.Parameters[(int)OperandParser.Ldarg(context.prevInstruction)];
                if (!p.Type.IsPointer)
                {
                    return;
                }
            }

            context.Pop($"rax");
            context.StackOperationCount -= 1;
            context.Push($"qword [rax]");
            context.StackOperationCount += 1;
        }
    }
}
