using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldind_I1)]
        public static void Ldind_I1(Context context)
        {
            Ldind_I8(context);
            Conv_I1(context);
        }
    }
}
