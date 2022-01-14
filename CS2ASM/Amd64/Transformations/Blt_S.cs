using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Blt_S)]
        public static void Blt_S(Context context)
        {
            Blt(context);
        }
    }
}
