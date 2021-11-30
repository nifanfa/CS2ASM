using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Br)]
        public static void Br(Arch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"jmp {Util.BrLabelName(ins, def)}");
        }
    }
}
