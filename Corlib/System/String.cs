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
        private char* Value;

        public char this[ulong index] 
        {
            get 
            {
                return Value[index];
            }
            set 
            {
                Value[index] = value;
            }
        }

        public static string Ctor(char* chr, ulong length)
        {
            String Str = new String();
            char* Char = stackalloc char[(int)length];
            x64.Movsb(Char, chr, length * 2);
            Str.Length = length;
            Str.Size = Str.Size + length * 2;
            Str.Value = Char;
            return Str;
        }
    }
}
