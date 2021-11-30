namespace ConsoleApp1
{
    public static unsafe class Program
    {
        public static void Main() 
        {
            byte* p = (byte*)0x140000000;
            *p = 0x41;

            byte* c = (byte*)0xb8000;
            *c = *p;
        }

        /*
        public static void Main()
        {
        Loop:
            Second();
            byte b = ReturnTest();
            byte* p = (byte*)0xb8000;
            *p = b;

            ArguTest(0x42);

            goto Loop;
        }

        public static void ArguTest(byte b) 
        {
            byte* p = (byte*)0xb8002;
            *p = b;
        }

        public static byte ReturnTest() { return 0x41; }

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
        */
    }
}
