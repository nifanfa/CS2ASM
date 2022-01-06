namespace System.Platform.Amd64
{
    public class Serial
    {
        public const ushort COM1 = 0x3F8;

        static Serial()
        {
            x64.Out8(COM1 + 1, 0x00);    // Disable all interrupts
            x64.Out8(COM1 + 3, 0x80);    // Enable DLAB (set baud rate divisor)
            x64.Out8(COM1 + 0, 0x03);    // Set divisor to 3 (lo byte) 38400 baud
            x64.Out8(COM1 + 1, 0x00);    //                  (hi byte)
            x64.Out8(COM1 + 3, 0x03);    // 8 bits, no parity, one stop bit
            x64.Out8(COM1 + 2, 0xC7);    // Enable FIFO, clear them, with 14-byte threshold
            x64.Out8(COM1 + 4, 0x0B);    // IRQs enabled, RTS/DSR set
        }

        public static void Write(string s)
        {
            for (ulong i = 0; i < s.Length; i++)
            {
                Write(s[i]);
            }
        }

        private static void Write(char c)
        {
            while ((x64.In8(COM1 + 5) & 0x20) == 0) { }
            x64.Out8(COM1, (byte)(c & 0xFF));
        }

        public static void WriteLine(string s)
        {
            Write(s);
            WriteLine();
        }

        public static void WriteLine()
        {
            Write('\r');
            Write('\n');
        }
    }
}
