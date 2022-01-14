using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Conv_U)]
        public static void Conv_U(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
        }
    }
}
