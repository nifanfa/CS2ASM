using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldind_Ref)]
        public static void Ldind_Ref(Context context)
        {
            throw new NotImplementedException("Ldind_Ref is not implemented");
        }
    }
}
