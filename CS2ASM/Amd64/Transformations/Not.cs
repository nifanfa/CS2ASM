using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Not)]
        public static void Not(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            context.Append($"pop rax");
            context.Append($"not rax");
            context.Append($"push rax");
        }
    }
}
