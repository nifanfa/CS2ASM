using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Not)]
        public static void Not(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"pop rax");
            arch.Append($"not rax");
            arch.Append($"push rax");
        }
    }
}
