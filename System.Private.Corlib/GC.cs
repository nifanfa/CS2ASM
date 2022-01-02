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
                desc[i].BlockSize = 0;
                continue;
            }
        }

        public static ulong Allocate(ulong s)
        {
            Allocation++;
            ulong ptr = 0;
            ulong size = s;
            if (MDs != null)
            {
                for (ulong i = 0; i < MDCount; i++)
                {
                    if ((&MDs[i])->BlockSize >= size)
                    {
                        ptr = (&MDs[i])->Address;
                        (&MDs[i])->Address = (&MDs[i])->Address + size;
                        (&MDs[i])->BlockSize = (&MDs[i])->BlockSize - size;
                        (&MDs[i])->BlockSize = 0;
                        return ptr;
                    }
                    continue;
                }
            }

            ptr = HeapStart;
            HeapStart = HeapStart + size;
            return ptr;
        }

        //Call.cs
        public static void Dispose(object obj) 
        {
            ulong p = Unsafe.AddressOf(obj);
            ulong size = obj.Size;
            obj = null;

            for (int i = 0; i < MDCount; i++)
            {
                if ((&MDs[i])->BlockSize == 0)
                {
                    (&MDs[i])->BlockSize = size;
                    (&MDs[i])->Address = p;
                    break; //Must Exist
                }
                continue;
            }

            x64.Stosb((void*)p, 0, size);

            Allocation--;
        }
    }
}
