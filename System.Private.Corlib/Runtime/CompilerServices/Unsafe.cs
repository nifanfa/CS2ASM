using static System.Runtime.Intrinsic;

namespace System.Runtime.CompilerServices
{
    public static class Unsafe
    {
        [CompilerMethod(Methods.Stackalloc)]
        public static ulong Stackalloc(ulong size)
        {
            return GC.Allocate(size);
        }

        public static ulong AddressOf(object obj) 
        {
            ulong p = 0;
            asm("mov rax,{obj}");
            asm("mov qword {p},rax");
            return p;
        }

        public static object GetObjectFromAddress(ulong p) 
        {
            object obj = null;
            asm("mov rax,{p}");
            asm("mov qword {obj},rax");
            return obj;
        }
    }
}
