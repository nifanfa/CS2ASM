using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldarg_S)]
        public static void Ldarg_S(BaseArch arch, Instruction ins, MethodDef def)
        {
            Ldarg(arch, ins, def);
        }
    }
}
