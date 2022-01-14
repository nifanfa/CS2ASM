using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Jmp)]
        public static void Jmp(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            throw new NotImplementedException("Jmp is not implemented");
        }
    }
}
