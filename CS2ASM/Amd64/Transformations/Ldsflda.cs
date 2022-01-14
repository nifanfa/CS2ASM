using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldsflda)]
        public static void Ldsflda(Context context)
        {
            //Ldarg.cs
            //Maybe wrong
            Ldsfld(context);
        }
    }
}
