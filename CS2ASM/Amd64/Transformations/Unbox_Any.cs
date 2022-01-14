using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Unbox_Any)]
        public static void Unbox_Any(Context context)
        {
            throw new NotImplementedException("Unbox_Any is not implemented");
        }
    }
}
