using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Conv_U)]
        public static void Conv_U(Context context)
        {
            Conv_I(context);
        }
    }
}
