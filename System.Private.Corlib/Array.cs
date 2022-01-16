using System.Runtime.CompilerServices;

namespace System
{
    public unsafe class Array
    {
        public ulong Length;

        [CompilerMethod(Methods.ArrayCtor)]
        public static object Ctor(ulong length, ulong itemSize)
        {
            //The allocation between object and stackalloc should be the same time
            Array array = new Array();

            //Memory reservation. check out Stelem.cs
            Unsafe.Stackalloc(length * itemSize);
            array.Size = array.Size + (ulong)(length * itemSize);

            array.Length = (ulong)length;

            return array;
        }
    }
}
