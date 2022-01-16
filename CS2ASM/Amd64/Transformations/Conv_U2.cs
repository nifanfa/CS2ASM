using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Conv_U2)]
        public static void Conv_U2(Context context)
        {
            Conv_I2(context);
        }
    }
}
