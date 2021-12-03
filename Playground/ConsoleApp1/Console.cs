
namespace ConsoleApp1
{
    public static unsafe class Console
    {
        private const byte Width = 80;
        private const byte Height = 25;

        private static byte Color = 0;
        private static ulong Position = 0;
        public static void Alphabet()
        {
            byte b = 0x41; // Start at 0x41 (character A)
            for (int i = 0; i < 26; i++) // Loop through next 25 characters after A
            {
                Write((char)b);
                b++;
            }
        }

        public static void AllSymbols()
        {
            byte b = 0x01; // Start at 0x01
            for (int i = 0; i < 256; i++)
            {
                Write((char)b);
                b++;
            }
        }

        public static void Setup()
        {
            BackgroundColor = ConsoleColor.Black;
            ForegroundColor = ConsoleColor.White;
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
