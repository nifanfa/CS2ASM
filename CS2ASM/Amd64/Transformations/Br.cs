using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Br)]
        public static void Br(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"jmp {Amd64.BrLabelName(ins, def)}");
        }
    }
}
