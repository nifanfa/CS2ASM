using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Conv_I8)]
        public static void Conv_I8(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"and qword [rsp+8],0xFFFFFFFFFFFFFFFF");
        }
    }
}
