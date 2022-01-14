using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Starg_S)]
        public static void Starg_S(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            Starg(arch, ins, def, context);
        }
    }
}
