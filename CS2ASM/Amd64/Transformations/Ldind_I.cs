using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldind_I)]
        public static void Ldind_I(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            Ldind_I8(arch, ins, def, context);
            Conv_I4(arch, ins, def, context);
        }
    }
}
