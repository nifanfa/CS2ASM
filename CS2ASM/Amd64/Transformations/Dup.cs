using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Dup)]
        public static void Dup(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Dup is not implemented");
        }
    }
}
