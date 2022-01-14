using CS2ASM.AMD64;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Br)]
        public static void Br(Context context)
        {
            context.Append($"jmp {Utility.BrLabelName(context.ins, context.def)}");
        }
    }
}
