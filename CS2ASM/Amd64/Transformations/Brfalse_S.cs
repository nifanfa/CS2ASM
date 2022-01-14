using CS2ASM.AMD64;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Brfalse_S)]
        public static void Brfalse_S(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            Brfalse(arch, ins, def, context);
        }
    }
}
