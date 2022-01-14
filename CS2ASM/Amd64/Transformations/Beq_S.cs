using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Beq_S)]
        public static void Beq_S(Context context)
        {
            Beq(context);
        }
    }
}
