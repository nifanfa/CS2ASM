using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldloc_1)]
        public static void Ldloc_1(BaseArch arch, Instruction ins, MethodDef def)
        {
            Ldloc(arch, ins, def);
        }
    }
}
