using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Refanytype)]
        public static void Refanytype(Context context)
        {
            throw new NotImplementedException("Refanytype is not implemented");
        }
    }
}
