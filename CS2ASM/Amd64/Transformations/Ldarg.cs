using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldarg)]
        public static void Ldarg(Context context)
        {
            context.Append($"mov qword rax,[rbp-{((ulong)context.def.Parameters.Count + 0 - OperandParser.Ldarg(context.ins)) * 8}]");
            context.Push($"rax");
            context.StackOperationCount += 1;
        }
    }
}
