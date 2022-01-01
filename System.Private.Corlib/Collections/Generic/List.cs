namespace System.Collections.Generic
{
    public class List<T>
    {
        private T[] value;

        public ulong Count = 0;

        public List(ulong initsize)
        {
            value = new T[initsize];
        }

        public T this[int index] 
        {
            get 
            {
                return value[index];
            }
        }

        public void Add(T t) 
        {
            value[Count] = t;
            Count++;
        }
    }
}
