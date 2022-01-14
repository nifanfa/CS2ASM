using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldvirtftn)]
        public static void Ldvirtftn(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            throw new NotImplementedException("Ldvirtftn is not implemented");
        }
    }
}
