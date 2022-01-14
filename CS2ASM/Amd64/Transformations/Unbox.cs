using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Unbox)]
        public static void Unbox(Context context)
        {
            throw new NotImplementedException("Unbox is not implemented");
        }
    }
}
