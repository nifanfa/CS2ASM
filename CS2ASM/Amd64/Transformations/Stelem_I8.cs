using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Stelem_I8)]
        public static void Stelem_I8(Context context)
        {
            DoStelem(context, 8);
        }
    }
}
