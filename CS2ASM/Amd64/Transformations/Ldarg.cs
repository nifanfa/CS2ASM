using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldarg)]
        public static void Ldarg(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"push qword [rbp+{((ulong)def.Parameters.Count + 0 - OperandParser.Ldarg(ins)) * 8}]");
        }
    }
}
