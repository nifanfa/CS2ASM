using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Pop)]
        public static void Pop(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            context.Append($"add rsp,8");
        }
    }
}
