using System.Runtime.CompilerServices;

namespace System
{
    public unsafe class Array
    {
        public int Length;

        [CompilerMethod(Methods.ArrayCtor)]
        public static object Ctor(int length)
        {
            //The allocation between object and stackalloc should be the same time
            Array array = new Array();

            //Fill the memory area check out Stelem.cs
            ulong* p = stackalloc ulong[length];
            array.Size = array.Size + (ulong)(length * 8);

            array.Length = length;

            return array;
        }
    }
}
