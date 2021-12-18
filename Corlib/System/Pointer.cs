
namespace System
{
    public struct Pointer
    {
        private readonly unsafe void* value;

        public static Pointer Zero
        {
            get { return new Pointer(0); }
        }

        public unsafe Pointer(int value)
        {
            this.value = (void*)value;
        }
    }
}
