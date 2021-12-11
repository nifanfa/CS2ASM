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

            ulong* Ptr = stackalloc ulong[3];
            //Not working
            Ptr[0] = (ulong)(sizeof(void*) * 2); //Object.Size
            Ptr[1] = Size;
            Ptr[2] = (ulong)Chr;

            asm("mov rax,{Ptr}");
            asm("mov {Str},rax");

            return Str;
        }
    }
}
