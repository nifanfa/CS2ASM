using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Unaligned)]
        public static void Unaligned(Context context)
        {
            throw new NotImplementedException("Unaligned is not implemented");
        }
    }
}
