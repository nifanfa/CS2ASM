using static System.Runtime.Intrinsic;

namespace Toolkit
{
    public static class IOPort
    {
        public static void Out16(ushort port, ushort value)
        {
            asm("mov rdx,{port}");
            asm("mov rax,{value}");
            asm("out dx,ax");
        }
    }
}
