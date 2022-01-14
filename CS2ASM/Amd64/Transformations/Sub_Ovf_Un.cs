using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Sub_Ovf_Un)]
        public static void Sub_Ovf_Un(Context context)
        {
            throw new NotImplementedException("Sub_Ovf_Un is not implemented");
        }
    }
}
