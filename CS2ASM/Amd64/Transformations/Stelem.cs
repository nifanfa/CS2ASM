using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Stelem)]
        public static void Stelem(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Stelem is not implemented");
        }
    }
}
