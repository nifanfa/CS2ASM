using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldc_I4_S)]
        public static void Ldc_I4_S(Context context)
        {
            Ldc_I4(context);
        }
    }
}
