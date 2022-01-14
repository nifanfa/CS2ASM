using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Stelem_I4)]
        public static void Stelem_I4(Context context)
        {
            DoStelem(context, 4);
        }
    }
}
