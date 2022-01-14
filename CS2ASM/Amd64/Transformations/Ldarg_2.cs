using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldarg_2)]
        public static void Ldarg_2(Context context)
        {
            Ldarg(context);
        }
    }
}
