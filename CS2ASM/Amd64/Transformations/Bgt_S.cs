using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Bgt_S)]
        public static void Bgt_S(Context context)
        {
            Bgt(context);
        }
    }
}
