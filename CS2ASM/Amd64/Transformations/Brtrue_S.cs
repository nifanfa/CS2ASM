using CS2ASM.AMD64;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Brtrue_S)]
        public static void Brtrue_S(Context context)
        {
            Brtrue(context);
        }
    }
}
