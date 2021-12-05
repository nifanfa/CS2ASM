using static System.Runtime.Intrinsic;

namespace Toolkit
{
    public static class IOPort
    {
        public static byte In8(ushort port)
        {
            byte data = 0;
            asm("mov rdx,{port}");
            asm("xor rax,rax");
            asm("in al,dx");
            asm("mov qword {data},rax");
            return data;
        }

        public static void Out16(ushort port, ushort value)
        {
            asm("mov rdx,{port}");
            asm("mov rax,{value}");
            asm("out dx,ax");
        }
    }
}
