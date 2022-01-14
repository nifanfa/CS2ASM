using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Stloc_S)]
        public static void Stloc_S(Context context)
        {
            Stloc(context);
        }
    }
}
