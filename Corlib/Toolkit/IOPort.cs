using static System.Runtime.Intrinsic;

namespace Toolkit
{
    public static class IOPort
    {
        public static void Out16(ushort port, ushort value)
        {
            asm("mov rdx,%-1");
            asm("mov rax,%-2");
            asm("out dx,ax");
        }
    }
}
