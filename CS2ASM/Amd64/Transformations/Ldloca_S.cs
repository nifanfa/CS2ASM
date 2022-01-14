using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldloca_S)]
        public static void Ldloca_S(Context context)
        {
            Ldloc_S(context);
        }
    }
}
