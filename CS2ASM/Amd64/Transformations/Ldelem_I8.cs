using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldelem_I8)]
        public static void Ldelem_I8(Context context)
        {
            DoLdelem(context, 8);
        }
    }
}
