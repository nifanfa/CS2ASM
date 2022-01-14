using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldind_I4)]
        public static void Ldind_I4(Context context)
        {
            Ldind_I8(context);
            Conv_I4(context);
        }
    }
}
