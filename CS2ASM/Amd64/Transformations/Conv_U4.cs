using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Conv_U4)]
        public static void Conv_U4(BaseArch arch, Instruction ins, MethodDef def)
        {
        }
    }
}
