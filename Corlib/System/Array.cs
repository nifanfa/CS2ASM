namespace System
{
    public unsafe class Array
    {
        public ulong* Data;

        public static object Ctor(int length)
        {
            Array array = new Array();
            ulong* p = stackalloc ulong[length];
            array.Data = p;

            return array;
        }
    }
}
