using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Clt)]
        public static void Clt(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            context.Append($"xor rbx,rbx");
            context.Append($"pop rdx");
            context.Append($"pop rax");
            context.Append($"cmp rax,rdx");
            context.Append($"setl bl");
            context.Append($"push rbx");
        }
    }
}
