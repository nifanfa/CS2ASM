using System.Runtime.CompilerServices;

namespace System.Runtime
{
    public static class Intrinsic
    {
        [CompilerMethod(Methods.ASM)]
        public static void asm(string comment) 
        { }
    }
}
