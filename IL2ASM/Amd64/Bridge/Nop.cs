using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Nop)]
        public static void Nop(Arch arch)
        {
        }
    }
}
