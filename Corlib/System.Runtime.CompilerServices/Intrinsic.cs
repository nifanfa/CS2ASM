namespace System.Runtime.CompilerServices
{
    public static class Intrinsic
    {
        //Newobj.cs
        public static ulong malloc()
        {
            return 0x640_0000UL;
        }
    }
}
