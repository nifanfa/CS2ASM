using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Sub_Ovf)]
        public static void Sub_Ovf(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Sub_Ovf is not implemented");
        }
    }
}
