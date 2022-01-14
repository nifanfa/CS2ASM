using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Prefix4)]
        public static void Prefix4(Context context)
        {
            throw new NotImplementedException("Prefix4 is not implemented");
        }
    }
}
