using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Prefix1)]
        public static void Prefix1(Context context)
        {
            throw new NotImplementedException("Prefix1 is not implemented");
        }
    }
}
