using static System.Runtime.CompilerServices.Unsafe;

namespace System.Platform.Amd64
{
    public class SSE
    {
        static SSE() 
        {
            asm("mov rax,cr0");
            asm("and ax,0xFFFB");
            asm("or ax,0x2");
            asm("mov cr0,rax");
            asm("mov rax,cr4");
            asm("or ax,3<<9");
            asm("mov cr4,rax");
        }
    }
}
