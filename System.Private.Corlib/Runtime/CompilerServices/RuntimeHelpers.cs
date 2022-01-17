namespace System.Runtime.CompilerServices
{
    public static unsafe class RuntimeHelpers
    {
        [CompilerMethod(Methods.InitialiseStatics)]
        public static void InitialiseStatics()
        {
            //This method will be filled by the compiler
        }

        public static unsafe int OffsetToStringData => sizeof(ulong) * 3;
    }
}
