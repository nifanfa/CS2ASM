using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Callvirt)]
        public static void Callvirt(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Callvirt is not implemented");
        }
    }
}
