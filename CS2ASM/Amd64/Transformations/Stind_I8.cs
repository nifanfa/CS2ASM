using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Stind_I8)]
        public static void Stind_I8(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"pop rdx");
            arch.Append($"pop rax");
            arch.Append($"mov [rax],rdx");
        }
    }
}
