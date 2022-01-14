using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Stind_R4)]
        public static void Stind_R4(Context context)
        {
            throw new NotImplementedException("Stind_R4 is not implemented");
        }
    }
}
