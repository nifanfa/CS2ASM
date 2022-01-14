using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldarg)]
        public static void Ldarg(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            context.Append($"mov qword rax,[rbp+{((ulong)def.Parameters.Count + 0 - OperandParser.Ldarg(ins)) * 8}]");
            context.Append($"push rax");
        }
    }
}
