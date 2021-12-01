using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Br_S)]
        public static void Br_S(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"jmp {Utility.BrLabelName(ins, def)}");
        }
    }
}
