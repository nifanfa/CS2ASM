namespace System.Platform.Amd64
{
    public static class PIC
    {
        public static void Enable()
        {
            x64.Out8(0x20, 0x11);
            x64.Out8(0xA0, 0x11);
            x64.Out8(0x21, 0x20);
            x64.Out8(0xA1, 40);
            x64.Out8(0x21, 0x04);
            x64.Out8(0xA1, 0x02);
            x64.Out8(0x21, 0x01);
            x64.Out8(0xA1, 0x01);
            x64.Out8(0x21, 0x0);
            x64.Out8(0xA1, 0x0);
        }

        public static void EOI(ulong irq)
        {
            if (irq >= 40)
                x64.Out8(0xA0, 0x20);

            x64.Out8(0x20, 0x20);
        }

        public static void ClearMask(byte irq)
        {
            ushort port;
            byte value;

            if (irq < 8)
            {
                port = 0x21;
            }
            else
            {
                port = 0xA1;
                irq -= 8;
            }
            value = (byte)(x64.In8(port) & ~(1 << irq));
            x64.Out8(port, value);
        }
    }
}
