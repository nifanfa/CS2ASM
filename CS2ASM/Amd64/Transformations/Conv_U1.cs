using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Conv_U1)]
        public static void Conv_U1(BaseArch arch, Instruction ins, MethodDef def)
        {
        }
    }
}
