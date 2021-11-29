namespace ConsoleApp1
{
    public static unsafe class Program
    {
        public static void Main()
        {
            Second();

        Die:
            byte b = Nothing();
            byte* p = (byte*)0xb8000;
            *p = b;

            goto Die;
        }

        public static byte Nothing() { return 0x41; }

        public static void Second()
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
            *p = (byte)'W';
            p += 2;
            *p = (byte)'o';
            p += 2;
            *p = (byte)'r';
            p += 2;
            *p = (byte)'l';
            p += 2;
            *p = (byte)'d';
        }
    }
}
