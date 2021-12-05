using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Stloc_1)]
        public static void Stloc_1(BaseArch arch, Instruction ins, MethodDef def)
        {
            Stloc(arch, ins, def);
        }
    }
}
