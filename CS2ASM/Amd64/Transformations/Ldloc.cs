using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldloc)]
        public static void Ldloc(BaseArch arch, Instruction ins, MethodDef def)
        {
            ulong Index = OperandParser.Ldloc(ins) + 1;
            arch.Append($"mov qword rax,[rbp-{Index * 8}]");
            arch.Append($"push rax");
        }
    }
}
