using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Stelem_R8)]
        public static void Stelem_R8(Context context)
        {
            throw new NotImplementedException("Stelem_R8 is not implemented");
        }
    }
}
