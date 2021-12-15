
namespace System.Runtime
{
    public static unsafe class GC
    {
        public struct MemoryDescriptor
        {
            public uint Address;
            public uint Size;
        }

        private static Pointer AllocateMemory(uint size)
        {
            return Pointer.Zero;
        }
    }
}
