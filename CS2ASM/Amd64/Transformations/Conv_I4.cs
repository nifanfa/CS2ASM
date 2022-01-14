using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Conv_I4)]
        public static void Conv_I4(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            context.Append($"and qword [rsp],0xFFFFFFFF");
        }
    }
}
