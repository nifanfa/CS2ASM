using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Conv_Ovf_U2)]
        public static void Conv_Ovf_U2(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Conv_Ovf_U2 is not implemented");
        }
    }
}
