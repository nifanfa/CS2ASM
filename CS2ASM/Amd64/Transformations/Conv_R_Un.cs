using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Conv_R_Un)]
        public static void Conv_R_Un(Context context)
        {
            throw new NotImplementedException("Conv_R_Un is not implemented");
        }
    }
}
