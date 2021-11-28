using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Conv_I)]
        public static void Conv_I(Arch arch, Instruction ins, MethodDef def)
        {
        }
    }
}
