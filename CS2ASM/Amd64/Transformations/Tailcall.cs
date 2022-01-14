using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Tailcall)]
        public static void Tailcall(Context context)
        {
            throw new NotImplementedException("Tailcall is not implemented");
        }
    }
}
