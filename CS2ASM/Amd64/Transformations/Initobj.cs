using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Initobj)]
        public static void Initobj(Context context)
        {
            throw new NotImplementedException("Initobj is not implemented");
        }
    }
}
