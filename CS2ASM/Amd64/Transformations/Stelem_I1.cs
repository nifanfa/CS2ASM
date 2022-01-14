using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Stelem_I1)]
        public static void Stelem_I1(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            Stelem(arch, ins, def, context);
        }
    }
}
