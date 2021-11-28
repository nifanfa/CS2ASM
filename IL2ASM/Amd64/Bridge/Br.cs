using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Br)]
        public static void Br(Arch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"jmp {Amd64.BrLabelName(ins, def)}");
        }
    }
}
