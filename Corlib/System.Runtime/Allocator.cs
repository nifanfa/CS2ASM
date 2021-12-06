namespace System.Runtime
{
    public static class Allocator
    {
        //Static value supported now
        public static ulong start = 0x6400000;

        //Newobj.cs
        public static ulong malloc(ulong size)
        {
            ulong ptr = start;
            start = start + size;
            return ptr;
        }
    }
}
