using System.Platform.Amd64;
using System.Runtime;
using System.Runtime.CompilerServices;
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

        public static string Ctor(char* Sample, ulong Length)
        {
            String Str = new String();
            char* Char = stackalloc char[(int)Length];
            x64.Movsb(Char, Sample, Length * 2);
            Str.Length = Length;
            Str.Size = Str.Size + Length * 2;
            Str.Value = Char;
            return Str;
        }
    }
}
