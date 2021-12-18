using static System.Runtime.Intrinsic;
using System.Runtime.CompilerServices;

namespace System.Runtime
{
    public static unsafe class GC
    {
        public struct MemoryDescriptor
        {
            public ulong Address;
            public ulong Size;
        }

        public static void Dispose(object obj) 
        {
            ulong p = Unsafe.AddressOf(obj);
            ulong size = obj.Size;
            asm("mov rdi,{p}");
            asm("mov rax,0");
            asm("mov rcx,{size}");
            asm("rep stosb");
        }
    }
}
