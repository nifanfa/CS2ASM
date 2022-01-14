using CS2ASM.AMD64;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Br)]
        public static void Br(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            context.Append($"jmp {Utility.BrLabelName(ins, def)}");
        }
    }
}
