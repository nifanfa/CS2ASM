using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Add_Ovf)]
        public static void Add_Ovf(Context context)
        {
            throw new NotImplementedException("Add_Ovf is not implemented");
        }
    }
}
