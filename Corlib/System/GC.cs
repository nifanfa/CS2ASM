namespace System
{
    public static class GC
    {
        //Static value supported now
        public static ulong MemoryStart = 0xA00000;

        //Newobj.cs
        public static ulong Allocate(ulong size)
        {
            ulong ptr = MemoryStart;
            MemoryStart = MemoryStart + size;
            return ptr;
        }
    }
}
