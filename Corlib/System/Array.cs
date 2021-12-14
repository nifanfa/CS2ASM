namespace System
{
    public unsafe class Array
    {
        public static object Ctor(int length)
        {
            Array array = new Array();
            ulong* p = stackalloc ulong[length];

            return array;
        }
    }
}
