namespace ConsoleApp1
{
    public static unsafe class Program
    {
        public static ulong Position = 0;

        public static void Main()
        {
            for(int i = 0; i < 10; i++) 
            {
                PutChar('A');
            }

            /*
            PutChar('H');
            PutChar('e');
            PutChar('l');
            PutChar('l');
            PutChar('o');
            */
        }

        public static void PutChar(char chr) 
        {
            byte* p = (byte*)(0xb8000 + Position);
            *p = (byte)chr;
            Position = Position + 2;
        }

        /*
        public static void Main()
        {
            if (Position == 0)
            {
                PutChar('Y');
            }
            else
            {
                PutChar('N');
            }

            if (Position == 1)
            {
                PutChar('Y');
            }
            else
            {
                PutChar('N');
            }
        }
        */

        /*
        public static void Main()
        {
            bool T = true;
            if (T)
            {
                PutChar('T');
            }
            else
            {
                PutChar('F');
            }

            bool F = false;
            if (F)
            {
                PutChar('T');
            }
            else
            {
                PutChar('F');
            }
        }
        */

        /*
        public static void ArguTest1(byte b1,byte b2)
        {
            byte* p0 = (byte*)0xb8000;
            *p0 = b1;

            byte* p1 = (byte*)0xb8002;
            *p1 = b2;
        }

        public static void Main()
        {
        Loop:
            Second();
            byte b = ReturnTest();
            byte* p = (byte*)0xb8000;
            *p = b;

            ArguTest(0x42);

            //ArguTest1(0x41, 0x42);

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
