using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldind_I2)]
        public static void Ldind_I2(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            Ldind_I8(arch, ins, def, context);
            Conv_I2(arch, ins, def, context);
        }
    }
}
