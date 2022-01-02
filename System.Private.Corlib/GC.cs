using static System.Runtime.Intrinsic;
using System.Runtime.CompilerServices;
using System.Platform.Amd64;

namespace System
{
    public static unsafe class GC
    {
        public struct MemoryDescriptor
        {
            public ulong Address;
            public ulong BlockSize;
        }
        private static MemoryDescriptor* Descs = null;
        private const int DescCount = 64;

        public static ulong HeapStart = 10 * 1024 * 1024;
        public static ulong Allocation = 0;

        static GC() 
        {
            MemoryDescriptor* desc = stackalloc MemoryDescriptor[DescCount];
            Descs = desc;

            for(int i = 0; i < DescCount; i++) 
            {
                desc[i].Address = 0;
                desc[i].BlockSize = 0;
                continue;
            }
        }

        public static ulong Allocate(ulong size)
        {
            Allocation++;
            ulong ptr = 0;
            for (ulong i = 0; i < DescCount; i++)
            {
                if (Descs == null) break;
                if ((&Descs[i])->BlockSize < size) continue;

                //In this case is CS2ASM got some problem
                //TO-DO find out what caused this problem (wrong size)
                if (size > 0xFFFFFFFF) break;
                if ((&Descs[i])->BlockSize > 0xFFFFFFFF) break;

                ptr = (&Descs[i])->Address;
                (&Descs[i])->Address = (&Descs[i])->Address + size;
                (&Descs[i])->BlockSize = (&Descs[i])->BlockSize - size;
                return ptr;
            }

            ptr = HeapStart;
            HeapStart = HeapStart + size;
            return ptr;
        }

        //Call.cs
        public static void Dispose(object obj) 
        {
            if (Descs == null) return;

            ulong p = Unsafe.AddressOf(obj);
            ulong size = obj.Size;
            obj = null;

            for (int i = 0; i < DescCount; i++)
            {
                if ((&Descs[i])->BlockSize == 0)
                {
                    (&Descs[i])->BlockSize = size;
                    (&Descs[i])->Address = p;
                    break; //Must Exist
                }
                continue;
            }

            x64.Stosb((void*)p, 0, size);

            Allocation--;
        }
    }
}
