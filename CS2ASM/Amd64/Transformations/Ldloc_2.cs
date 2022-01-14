using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldloc_2)]
        public static void Ldloc_2(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            Ldloc(arch, ins, def, context);
        }
    }
}
