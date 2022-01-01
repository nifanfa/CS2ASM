using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldind_I4)]
        public static void Ldind_I4(BaseArch arch, Instruction ins, MethodDef def)
        {
            Ldind_I8(arch, ins, def);
            Conv_I4(arch, ins, def);
        }
    }
}
