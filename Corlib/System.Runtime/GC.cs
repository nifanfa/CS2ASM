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
        private static MemoryDescriptor* MDs = null;
        private const int MDCount = 1024;

        public static ulong HeapStart = 10 * 1024 * 1024;
        public static ulong Allocation = 0;

        static GC() 
        {
            MemoryDescriptor* desc = stackalloc MemoryDescriptor[MDCount];
            MDs = desc;

            for(int i = 0; i < MDCount; i++) 
            {
                desc[i].Address = 0;
                desc[i].Size = 0;
            }
        }

        public static ulong Allocate(ulong size)
        {
            Allocation++;

            if (MDs != null)
            {
                for (ulong i = 0; i < MDCount; i++)
                {
                    if (MDs[i].Size >= size)
                    {
                        MDs[i].Address = MDs[i].Address + size;
                        MDs[i].Size = MDs[i].Size - size;
                        return MDs[i].Address;
                    }
                }
            }

            ulong ptr = HeapStart;
            HeapStart = HeapStart + size;
            return ptr;
        }

        public static void Dispose(object obj) 
        {
            ulong p = Unsafe.AddressOf(obj);
            ulong size = obj.Size;

            for (int i = 0; i < MDCount; i++)
            {
                if (MDs[i].Size == 0)
                {
                    MDs[i].Size = size;
                    MDs[i].Address = p;
                    break; //Must Exist
                }
            }

            Allocation--;

            asm("mov rdi,{p}");
            asm("xor rax,rax");
            asm("mov rcx,{size}");
            asm("rep stosb");
        }
    }
}
