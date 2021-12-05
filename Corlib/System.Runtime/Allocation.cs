namespace System.Runtime
{
    public static class Allocation
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
