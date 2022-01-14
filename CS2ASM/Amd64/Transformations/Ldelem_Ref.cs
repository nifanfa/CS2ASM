using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldelem_Ref)]
        public static void Ldelem_Ref(Context context)
        {
            DoLdelem(context, 8);
        }
    }
}
