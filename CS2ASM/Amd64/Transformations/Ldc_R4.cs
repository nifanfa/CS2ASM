using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldc_R4)]
        public static void Ldc_R4(Context context)
        {
            throw new NotImplementedException("Ldc_R4 is not implemented");
        }
    }
}
