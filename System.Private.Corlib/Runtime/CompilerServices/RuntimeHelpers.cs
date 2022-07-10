namespace System.Runtime.CompilerServices
{
    public static unsafe class RuntimeHelpers
    {
        public static unsafe int OffsetToStringData => sizeof(ulong) * 3;
    }
}
