using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Conv_I2)]
        public static void Conv_I2(Context context)
        {
            context.Append($"and qword [rsp],0xFFFF");
        }
    }
}
