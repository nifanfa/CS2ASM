using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Bge_S)]
        public static void Bge_S(Context context)
        {
            Bge(context);
        }
    }
}
