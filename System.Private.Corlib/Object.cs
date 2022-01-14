using System.Runtime;
using static System.Runtime.CompilerServices.Unsafe;

namespace System
{
    public class Object
    {
        //Newobj.cs
        public ulong Size;

        public virtual void Dispose() 
        {
            GC.Dispose(this);
        }

        private static string DefaultString = "System.Object";

        public virtual string ToString() 
        {
            return DefaultString;
        }
    }
}