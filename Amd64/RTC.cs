namespace System.Platform.Amd64
{
    public static class RTC
    {
        private static byte B;

        public static byte Get(byte index)
        {
            x64.Out8(0x70, index);
            byte result = x64.In8(0x71);

            return result;
        }

        public static void Set(byte index, byte value)
        {
            x64.Out8(0x70, index);
            x64.Out8(0x71, value);
        }

        private static void Delay()
        {
            x64.In8(0x80);
            x64.Out8(0x80, 0);
        }

        public static byte Second
        {
            get
            {
                B = Get(0);
                return (byte)((B & 0x0F) + ((B / 16) * 10));
            }
        }

        public static byte Minute
        {
            get
            {
                B = Get(2);
                return (byte)((B & 0x0F) + ((B / 16) * 10));
            }
        }

        public static byte Hour
        {
            get
            {
                B = Get(4);
                return (byte)(((B & 0x0F) + ((B & 0x70) / 16 * 10)) | (B & 0x80));
            }
        }

        public static byte Century
        {
            get
            {
                B = Get(0x32);
                return (byte)((B & 0x0F) + ((B / 16) * 10));
            }
        }

        public static byte Year
        {
            get
            {
                B = Get(9);
                return (byte)((B & 0x0F) + ((B / 16) * 10));
            }
        }

        public static byte Month
        {
            get
            {
                B = Get(8);
                return (byte)((B & 0x0F) + ((B / 16) * 10));
            }
        }

        public static byte Day
        {
            get
            {
                B = Get(7);
                return (byte)((B & 0x0F) + ((B / 16) * 10));
            }
        }

        public static bool BCD { get { return (Get(0x0B) & 0x04) == 0x00; } }
    }
}
