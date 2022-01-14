using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldflda)]
        public static void Ldflda(Context context)
        {
            Ldfld(context);
        }
    }
}
