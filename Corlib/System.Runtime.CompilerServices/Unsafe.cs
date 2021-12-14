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
    }
}
