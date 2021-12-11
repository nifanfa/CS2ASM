namespace System.Runtime.CompilerServices
{
    public static class Unsafe
    {
        //10 Megabytes
        public static ulong MemoryStart = 0xA00000;

        public static ulong Stackalloc(ulong size)
        {
            ulong ptr = MemoryStart;
            MemoryStart = MemoryStart + size;
            return ptr;
        }
    }
}
