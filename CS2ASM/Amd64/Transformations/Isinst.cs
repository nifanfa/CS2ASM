using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Isinst)]
        public static void Isinst(Context context)
        {
            throw new NotImplementedException("Isinst is not implemented");
        }
    }
}
