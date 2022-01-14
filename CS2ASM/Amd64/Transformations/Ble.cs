using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ble)]
        public static void Ble(Context context)
        {
            throw new NotImplementedException("Ble is not implemented");
        }
    }
}
