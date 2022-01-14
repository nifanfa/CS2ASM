using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Switch)]
        public static void Switch(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            throw new NotImplementedException("Switch is not implemented");
        }
    }
}
