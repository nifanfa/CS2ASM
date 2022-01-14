using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldelem_I1)]
        public static void Ldelem_I1(Context context)
        {
            DoLdelem(context, 1);
        }
    }
}
