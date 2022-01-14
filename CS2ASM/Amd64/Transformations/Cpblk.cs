using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Cpblk)]
        public static void Cpblk(Context context)
        {
            throw new NotImplementedException("Cpblk is not implemented");
        }
    }
}
