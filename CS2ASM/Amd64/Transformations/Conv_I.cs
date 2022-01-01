using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Conv_I)]
        public static void Conv_I(BaseArch arch, Instruction ins, MethodDef def)
        {
            //arch.Append($"and qword [rsp],0xFFFFFFFF");
        }
    }
}
