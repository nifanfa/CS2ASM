using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Blt_Un_S)]
        public static void Blt_Un_S(Context context)
        {
            Blt(context);
        }
    }
}
