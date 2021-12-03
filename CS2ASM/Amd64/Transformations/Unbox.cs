using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Unbox)]
        public static void Unbox(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Unbox is not implemented");
        }
    }
}
