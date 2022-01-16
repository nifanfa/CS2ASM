using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Conv_U1)]
        public static void Conv_U1(Context context)
        {
            Conv_I1(context);
        }
    }
}
