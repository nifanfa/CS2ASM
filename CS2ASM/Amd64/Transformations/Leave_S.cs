using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Leave_S)]
        public static void Leave_S(Context context)
        {
            throw new NotImplementedException("Leave_S is not implemented");
        }
    }
}
