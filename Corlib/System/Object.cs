using System.Runtime;
using static System.Runtime.Intrinsic;

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
    }
}