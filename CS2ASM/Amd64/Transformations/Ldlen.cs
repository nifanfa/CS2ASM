using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldlen)]
        public static void Ldlen(Context context)
        {
            throw new NotImplementedException("Ldlen is not implemented");
        }
    }
}
