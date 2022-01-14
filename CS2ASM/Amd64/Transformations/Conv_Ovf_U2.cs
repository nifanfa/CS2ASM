using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Conv_Ovf_U2)]
        public static void Conv_Ovf_U2(Context context)
        {
            throw new NotImplementedException("Conv_Ovf_U2 is not implemented");
        }
    }
}
