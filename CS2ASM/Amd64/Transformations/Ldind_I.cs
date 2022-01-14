using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldind_I)]
        public static void Ldind_I(Context context)
        {
            Ldind_I8(context);
            Conv_I4(context);
        }
    }
}
