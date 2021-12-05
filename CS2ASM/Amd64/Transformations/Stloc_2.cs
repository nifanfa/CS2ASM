using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Stloc_2)]
        public static void Stloc_2(BaseArch arch, Instruction ins, MethodDef def)
        {
            Stloc(arch, ins, def);
        }
    }
}
