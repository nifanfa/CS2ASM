using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldarg_3)]
        public static void Ldarg_3(BaseArch arch, Instruction ins, MethodDef def)
        {
            Ldarg(arch, ins, def);
        }
    }
}
