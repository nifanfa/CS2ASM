using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Box)]
        public static void Box(Context context)
        {
            throw new NotImplementedException("Box is not implemented");
        }
    }
}
