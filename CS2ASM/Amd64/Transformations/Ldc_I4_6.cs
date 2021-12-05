using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldc_I4_6)]
        public static void Ldc_I4_6(BaseArch arch, Instruction ins, MethodDef def)
        {
            Ldc_I4(arch, ins, def);
        }
    }
}
