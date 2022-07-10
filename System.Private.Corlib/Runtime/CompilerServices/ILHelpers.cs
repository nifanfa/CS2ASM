namespace System.Runtime.CompilerServices
{
    internal unsafe class ILHelpers
    {
        [CompilerMethod(Methods.Newobj)]
        public static object Newobj(ulong size) 
        {
            var p = GC.Allocate(size);
            var obj = Unsafe.GetObjectFromAddress(p);
            obj.Size = size;
            return obj;
        }
    }
}
