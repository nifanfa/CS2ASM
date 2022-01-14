using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Endfinally)]
        public static void Endfinally(Context context)
        {
            throw new NotImplementedException("Endfinally is not implemented");
        }
    }
}
