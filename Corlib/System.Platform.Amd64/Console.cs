namespace System.Platform.Amd64
{
    public static unsafe class Console
    {
        public const byte Width = 80;
        public const byte Height = 25;

        private static byte Color = 0;
        private static ulong Position = 0;

        static Console()
        {
            ResetColor();
            Clear();
        }

        public static void Write(string s)
        {
            for (byte i = 0; i < s.Length; i++)
            {
                Console.Write(s[i]);
            }
        }

        public static void ResetColor()
        {
            BackgroundColor = ConsoleColor.Black;
            ForegroundColor = ConsoleColor.White;
        }

        public static void Write(char chr)
        {
            byte* p = ((byte*)(0xb8000 + Position));
            * p = (byte)chr;
            p++;
            *p = Color;
            Position += 2;
        }

        public static void WriteAt(char chr, byte x, byte y)
        {
            byte* p = (byte*)0xb8000 + ((y * Width + x) * 2);
            *p = (byte)chr;
            p++;
            *p = Color;
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
    }
}
