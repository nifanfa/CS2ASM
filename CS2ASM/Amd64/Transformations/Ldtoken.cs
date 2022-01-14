using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldtoken)]
        public static void Ldtoken(Context context)
        {
            throw new NotImplementedException("Ldtoken is not implemented");
        }
    }
}
