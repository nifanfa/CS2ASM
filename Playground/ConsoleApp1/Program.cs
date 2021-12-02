namespace ConsoleApp1
{
    public static unsafe class Program
    {

        // Colors
        private const byte Black = 0x00;
        private const byte Blue = 0x01;
        private const byte Green = 0x02;
        private const byte Cyan = 0x03;
        private const byte Red = 0x04;
        private const byte Purple = 0x05;
        private const byte Brown = 0x06;
        private const byte Gray = 0x07;
        private const byte DarkGray = 0x08;
        private const byte LightBlue = 0x09;
        private const byte LightGreen = 0x0A;
        private const byte LightCyan = 0x0B;
        private const byte LightRed = 0x0C;
        private const byte LightPurple = 0x0D;
        private const byte Yellow = 0x0E;
        private const byte White = 0x0F;

        private const byte Width = 80;
        private const byte Height = 25;

        private static byte Color = 0;
        private static ulong Position = 0;

        /*
         * Current Progress:
         *  Only static methods supported.
         *  Only local and static variables supported.
         *  Pointers supported.
         *  SByte, Byte, Short, UShort, Int, UInt, Long, ULong, are all supported.
         *  C# basic things (for, if, etc, return, and more) supported.
         *  
         *  Allocation is not yet supported!
         */
        public static void Main()
        {
            SetupConsole();
            AllSymbols();
        }

        private static void Alphabet()
        {
            byte b = 0x41; // Start at 0x41 (character A)
            for (int i = 0; i < 26; i++) // Loop through next 25 characters after A
            {
                Write((char)b);
                b++;
            }
        }

        private static void AllSymbols()
        {
            byte b = 0x01; // Start at 0x01
            for (int i = 0; i < 256; i++)
            {
                Write((char)b);
                b++;
            }
        }

        public static void SetupConsole()
        {
            BackgroundColor = Black;
            ForegroundColor = White;
            Clear();
        }

        public static void Write(char chr)
        {
            byte* p = GetVideoAddress();
            *p = (byte)chr;
            p++;
            *p = Color;
            Position += 2;
        }

        public static void WriteF(char chr, byte fg)
        {
            byte pfg = ForegroundColor;
            ForegroundColor = fg;
            Write(chr);
            ForegroundColor = pfg;
        }

        public static void WriteB(char chr, byte bg)
        {
            byte pbg = BackgroundColor;
            BackgroundColor = bg;
            Write(chr);
            BackgroundColor = pbg;
        }

        public static void WriteFB(char chr, byte fg, byte bg)
        {
            byte bfg = ForegroundColor;
            byte pbg = BackgroundColor;
            ForegroundColor = fg;
            BackgroundColor = bg;
            Write(chr);
            ForegroundColor = bfg;
            BackgroundColor = pbg;
        }

        public static void Clear()
        {
            Position = 0;
            int Res = Width * Height;
            for (int i = 0; i < Res; i++)
            {
                Write(' ');
            }
            Position = 0;
        }

        public static byte ForegroundColor
        {
            get { return (byte)(Color & 0x0F); }
            set { Color &= 0xF0; Color |= (byte)(value & 0x0F); }
        }

        public static byte BackgroundColor
        {
            get { return (byte)(Color >> 4); }
            set { Color &= 0x0F; Color |= (byte)((value & 0x0F) << 4); }
        }

        private static byte* GetVideoAddress()
        {
            return (byte*)(0xb8000 + Position);
        }
    }
}
