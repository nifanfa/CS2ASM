using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldind_R4)]
        public static void Ldind_R4(Context context)
        {
            throw new NotImplementedException("Ldind_R4 is not implemented");
        }
    }
}
