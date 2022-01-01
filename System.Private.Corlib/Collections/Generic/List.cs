namespace System.Collections.Generic
{
    public class List<T>
    {
        T[] ts;
        private ulong index = 0;

        public List(ulong length)
        {
            ts = new T[length];
        }

        public T this[int index] 
        {
            get 
            {
                return ts[index];
            }
        }

        public void Add(T t) 
        {
            ts[index] = t;
            index++;
        }
    }

    public class TList
    {
        ulong[] ts;
        private ulong index = 0;

        public TList(ulong length)
        {
            ts = new ulong[length];
        }

        public ulong this[int index]
        {
            get
            {
                return ts[index];
            }
        }

        public void Add(ulong t)
        {
            ts[index] = t;
            index++;
        }
    }
}
