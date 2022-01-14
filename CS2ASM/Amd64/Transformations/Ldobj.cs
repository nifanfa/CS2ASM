using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldobj)]
        public static void Ldobj(Context context)
        {
            throw new NotImplementedException("Ldobj is not implemented");
        }
    }
}
