using System.Runtime.CompilerServices;

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

        [CompilerMethod(Methods.Allocate)]
        public static ulong Allocate(ulong size)
        {
            Allocation++;
            ulong ptr = 0;
            for (ulong i = 0; i < DescCount; i++)
            {
                if (
                    Descs != null &&
                    (&Descs[i])->BlockSize >= size
                    )
                {
                    (&Descs[i])->Address = (&Descs[i])->Address + size;
                    (&Descs[i])->BlockSize = (&Descs[i])->BlockSize - size;                    (&Descs[i])->BlockSize = 0;
                    return (&Descs[i])->Address - size;
                }
            }

            ptr = HeapStart;
            HeapStart = HeapStart + size;
            return ptr;
        }

        //Call.cs
        [CompilerMethod(Methods.Dispose)]
        public static void Dispose(object obj) 
        {
            if (Descs == null) return;

            ulong p = Unsafe.AddressOf(obj);
            ulong size = obj.Size;
            obj = null;

            Free(p, size);
        }

        internal static void Free(ulong p, ulong size)
        {
            for (int i = 0; i < DescCount; i++)
            {
                if ((&Descs[i])->BlockSize == 0)
                {
                    (&Descs[i])->BlockSize = size;
                    (&Descs[i])->Address = p;
                    break; //Must Exist
                }
            }

            Platform.Amd64.Native.Stosb((void*)p, 0, size);
            Allocation--;
        }
    }
}
