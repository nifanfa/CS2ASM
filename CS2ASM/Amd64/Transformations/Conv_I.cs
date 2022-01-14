using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Conv_I)]
        public static void Conv_I(Context context)
        {
            context.Append($"and qword [rsp],0xFFFFFFFF");
        }
    }
}
