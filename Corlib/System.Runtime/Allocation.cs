namespace System.Runtime
{
    public static class Allocation
    {
        //Newobj.cs
        public static ulong malloc()
        {
            return 0x6400000;
        }
    }
}
