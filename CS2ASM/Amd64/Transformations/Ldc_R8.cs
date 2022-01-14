using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldc_R8)]
        public static void Ldc_R8(Context context)
        {
            throw new NotImplementedException("Ldc_R8 is not implemented");
        }
    }
}
