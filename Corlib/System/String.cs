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
        public char* Value;
    }
}
