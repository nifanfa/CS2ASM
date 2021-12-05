using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Mul)]
        public static void Mul(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"pop rbx");
            arch.Append($"pop rax");
            arch.Append($"mul rbx");
            arch.Append($"push rax");
        }
    }
}
