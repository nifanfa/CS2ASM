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
        public char* Value;

        public char this[ulong index] 
        {
            get => Value[index];
            set => Value[index] = value;
        }

        [CompilerMethod(Methods.StringCtor)]
        public static string Ctor(char* chr, ulong length)
        {
            var str = new string();
            var schr = stackalloc char[(int)length];

            Native.Movsb(schr, chr, length * 2);

            str.Length = length;
            str.Size += length * 2;
            str.Value = schr;
            return str;
        }

        public static bool operator ==(string a,string b) 
        {
            if (a.Length != b.Length)
                return false;

            for (ulong i = 0; i < a.Length; i++)
                if (a[i] != b[i]) return false;

            return true;
        }

        public static bool operator !=(string a, string b)
        {
            return !(a == b);
        }
    }
}
