namespace System.Runtime
{
    public static class Allocation
    {
        public static ulong start = 0;

        //Newobj.cs
        public static ulong malloc()
        {
            start = start + 128UL;
            return start;
        }
    }
}
