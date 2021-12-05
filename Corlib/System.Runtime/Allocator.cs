namespace System.Runtime
{
    public static class Allocator
    {
        public static ulong start = 0;

        //Newobj.cs
        public static ulong malloc(ulong size)
        {
            ulong ptr = start;
            start = start + size;
            return ptr;
        }
    }
}
