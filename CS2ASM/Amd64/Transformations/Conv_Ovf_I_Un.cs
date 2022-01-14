using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Conv_Ovf_I_Un)]
        public static void Conv_Ovf_I_Un(Context context)
        {
            Conv_I(context);
        }
    }
}
