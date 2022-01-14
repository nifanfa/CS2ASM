using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Prefix6)]
        public static void Prefix6(Context context)
        {
            throw new NotImplementedException("Prefix6 is not implemented");
        }
    }
}
