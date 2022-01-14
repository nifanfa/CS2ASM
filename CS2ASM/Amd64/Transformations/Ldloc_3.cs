using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldloc_3)]
        public static void Ldloc_3(Context context)
        {
            Ldloc(context);
        }
    }
}
