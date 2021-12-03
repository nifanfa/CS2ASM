using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Conv_R_Un)]
        public static void Conv_R_Un(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Conv_R_Un is not implemented");
        }
    }
}
