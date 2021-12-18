using static System.Runtime.Intrinsic;

namespace System.Runtime.CompilerServices
{
    public static class Unsafe
    {
        public static ulong AllocationCount = 0;
        //10 Megabytes
        public static ulong MemoryStart = 0xA00000;

        public static ulong Stackalloc(ulong size)
        {
            AllocationCount++;
            ulong ptr = MemoryStart;
            MemoryStart = MemoryStart + size;
            return ptr;
        }

        public static ulong AddressOf(object obj) 
        {
            ulong p = 0;
            asm("mov rax,{obj}");
            asm("mov qword {p},rax");
            return p;
        }

        public static object GetObjectFromAddress(ulong p) 
        {
            object obj = null;
            asm("mov rax,{p}");
            asm("mov qword {obj},rax");
            return obj;
        }
    }
}
