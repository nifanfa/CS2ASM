using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Newarr)]
        public static void Newarr(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Newarr is not implemented");
        }
    }
}
