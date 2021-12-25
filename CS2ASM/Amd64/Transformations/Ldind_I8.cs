using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldind_I8)]
        public static void Ldind_I8(BaseArch arch, Instruction ins, MethodDef def)
        {
            Ldind_I(arch, ins, def);
        }
    }
}
