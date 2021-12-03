using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Ldind_Ref)]
        public static void Ldind_Ref(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldind_Ref is not implemented");
        }
    }
}
