using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Nop)]
        public static void Nop(BaseArch arch, Instruction ins, MethodDef def)
        {
        }
    }
}
