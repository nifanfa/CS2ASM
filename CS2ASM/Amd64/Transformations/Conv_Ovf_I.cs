using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Conv_Ovf_I)]
        public static void Conv_Ovf_I(Context context)
        {
            throw new NotImplementedException("Conv_Ovf_I is not implemented");
        }
    }
}
