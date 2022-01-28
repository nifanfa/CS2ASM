namespace System.Runtime.CompilerServices
{
    internal unsafe class ILHelpers
    {
        [CompilerMethod(Methods.Newobj)]
        public static object Newobj(ulong size) 
        {
            ulong p = GC.Allocate(size);
            object obj = Unsafe.GetObjectFromAddress(p);
            obj.Size = size;
            return obj;
        }
    }
}
