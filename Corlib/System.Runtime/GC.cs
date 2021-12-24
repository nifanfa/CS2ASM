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

        public static ulong HeapStart = 10 * 1024 * 1024;
        public static ulong Allocation = 0;

        public static ulong Allocate(ulong size)
        {
            Allocation++;
            ulong ptr = HeapStart;
            HeapStart = HeapStart + size;
            return ptr;
        }

        public static void Dispose(object obj) 
        {
            ulong p = Unsafe.AddressOf(obj);
            ulong size = obj.Size;
            asm("mov rdi,{p}");
            asm("xor rax,rax");
            asm("not rax");
            asm("mov rcx,{size}");
            asm("rep stosb");
        }
    }
}
