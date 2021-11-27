namespace ConsoleApp1
{
    public static class Program
    {
        public static unsafe void Main()
        {
            byte* p = (byte*)0xb8000;

            *p = (byte)'H';
            p += 2;
            *p = (byte)'e';
            p += 2;
            *p = (byte)'l';
            p += 2; 
            *p = (byte)'l';
            p += 2;
            *p = (byte)'o';
            p += 2;
            *p = (byte)' ';
            p += 2;
            *p = (byte)'L';
            p += 2;
            *p = (byte)'e';
            p += 2;
            *p = (byte)'o';
            p += 2;
            *p = (byte)'n';
        }
    }
}
