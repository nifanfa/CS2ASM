using static System.Runtime.CompilerServices.Unsafe;

namespace System.Platform.Amd64
{
    public static unsafe class Native
    {
        public static void Hlt()
        {
            asm("hlt");
        }

        public static void Pause()
        {
            asm("pause");
        }

        public static void Movsb(void* dest, void* source, ulong count)
        {
            asm("mov rcx,{count}");
            asm("mov rdi,{dest}");
            asm("mov rsi,{source}");
            asm("rep movsb");
        }

        public static void Movsd(void* dest, void* source, ulong count)
        {
            asm("mov rcx,{count}");
            asm("mov rdi,{dest}");
            asm("mov rsi,{source}");
            asm("rep movsd");
        }

        public static void Stosb(void* dest, uint value, ulong count)
        {
            asm("mov rcx,{count}");
            asm("mov rdi,{dest}");
            asm("mov rax,{value}");
            asm("rep stosb");
        }

        public static void Stosd(void* dest, uint value, ulong count)
        {
            asm("mov rcx,{count}");
            asm("mov rdi,{dest}");
            asm("mov rax,{value}");
            asm("rep stosd");
        }

        public static uint In32(ushort port)
        {
            uint data = 0;
            asm("mov rdx,{port}");
            asm("xor rax,rax");
            asm("in eax,dx");
            asm("mov qword {data},rax");
            return data;
        }

        public static ushort In16(ushort port)
        {
            ushort data = 0;
            asm("mov rdx,{port}");
            asm("xor rax,rax");
            asm("in ax,dx");
            asm("mov qword {data},rax");
            return data;
        }

        public static void Invlpg(ulong ptr)
        {
            asm("invlpg {ptr}");
        }

        public static byte In8(ushort port)
        {
            byte data = 0;
            asm("mov rdx,{port}");
            asm("xor rax,rax");
            asm("in al,dx");
            asm("mov qword {data},rax");
            return data;
        }

        public static void Out8(ushort port, byte value)
        {
            asm("mov rdx,{port}");
            asm("mov rax,{value}");
            asm("out dx,al");
        }

        public static void Out16(ushort port, ushort value)
        {
            asm("mov rdx,{port}");
            asm("mov rax,{value}");
            asm("out dx,ax");
        }

        public static void Out32(ushort port, uint value)
        {
            asm("mov rdx,{port}");
            asm("mov rax,{value}");
            asm("out dx,eax");
        }
    }
}
