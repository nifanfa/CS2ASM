using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Jmp)]
        public static void Jmp(Context context)
        {
            throw new NotImplementedException("Jmp is not implemented");
        }
    }
}
