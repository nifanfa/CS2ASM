namespace System
{
    public unsafe class Array
    {
        public static object Ctor(int length)
        {
            Array array = new Array();

            //Fill the memory area check out Stelem.cs
            ulong* p = stackalloc ulong[length];

            return array;
        }
    }
}
