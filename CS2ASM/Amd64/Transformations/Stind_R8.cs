using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Stind_R8)]
        public static void Stind_R8(Context context)
        {
            throw new NotImplementedException("Stind_R8 is not implemented");
        }
    }
}
