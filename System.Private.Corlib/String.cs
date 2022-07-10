using System.Platform.Amd64;
using System.Runtime.CompilerServices;

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
            var len = length * 2;
            var schr = stackalloc char[(int)length];

            Native.Movsb(schr, chr, len);

            str.Length = length;
            str.Size += len;
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
