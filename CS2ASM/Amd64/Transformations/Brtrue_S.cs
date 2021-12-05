using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Brtrue_S)]
        public static void Brtrue_S(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"pop rax");
            arch.Append($"cmp rax,1");
            arch.Append($"je {Amd64.BrLabelName(ins, def)}");
        }
    }
}
