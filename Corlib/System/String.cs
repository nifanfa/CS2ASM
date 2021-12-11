using System.Runtime;
using static System.Runtime.Intrinsic;

namespace System
{
    /*
     * Memory layout:
     * ulong length size:8
     * char* value size:8
     * Unicode string size:∞
     */
    public unsafe class String
    {
        public ulong Length;
        public char* Value;

        public static string Ctor(char* Chr, ulong Size)
        {
            //Ldnull can be a way freeing objects
            string Str = null;

            ulong* Ptr = (ulong*)Allocator.malloc((ulong)sizeof(void*) * 2);
            Ptr[0] = Size;
            Ptr[1] = (ulong)Chr;

            asm("mov rax,{Ptr}");
            asm("mov {Str},rax");

            return Str;
        }
    }
}
