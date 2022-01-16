using System.Platform.Amd64;
using System.Runtime;
using System.Runtime.CompilerServices;
using static System.Runtime.CompilerServices.Unsafe;

namespace System
{
    /*
     * Memory layout:
     * ulong length size:8
     * char* value size:8
     * Unicode string size:∞
     */
    /// <summary>
    /// You don't have to dispose strings.
    /// </summary>
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

        [CompilerMethod(Methods.StringCtor)]
        public static string Ctor(char* chr, ulong length)
        {
            String Str = new String();
            char* Char = stackalloc char[(int)length];
            Platform.Amd64.Native.Movsb(Char, chr, length * 2);
            Str.Length = length;
            Str.Size = Str.Size + length * 2;
            Str.Value = Char;
            return Str;
        }

        public static bool operator == (string a,string b) 
        {
            if (a.Length != b.Length) return false;

            for (ulong i = 0; i < a.Length; i++) 
            {
                if (a[i] != b[i]) return false;
            }
            return true;
        }

        public static bool operator !=(string a, string b)
        {
            return !(a == b);
        }
    }
}
