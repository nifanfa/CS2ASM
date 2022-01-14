using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Prefix2)]
        public static void Prefix2(Context context)
        {
            throw new NotImplementedException("Prefix2 is not implemented");
        }
    }
}
