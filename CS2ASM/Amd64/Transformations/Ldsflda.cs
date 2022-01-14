using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldsflda)]
        public static void Ldsflda(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            //Ldarg.cs
            //Maybe wrong
            Ldsfld(arch, ins, def, context);
        }
    }
}
