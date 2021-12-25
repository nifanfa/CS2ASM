using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldind_U4)]
        public static void Ldind_U4(BaseArch arch, Instruction ins, MethodDef def)
        {
            Ldind_U1(arch, ins, def);
        }
    }
}
