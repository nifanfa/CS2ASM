using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Clt_Un)]
        public static void Clt_Un(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            Clt(arch, ins, def, context);
        }
    }
}
