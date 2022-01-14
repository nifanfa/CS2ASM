using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldarg_0)]
        public static void Ldarg_0(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            Ldarg(arch, ins, def, context);
        }
    }
}
