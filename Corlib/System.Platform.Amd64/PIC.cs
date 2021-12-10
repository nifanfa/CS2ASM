namespace System.Platform.Amd64
{
    public static class PIC
    {
        public static void Enable()
        {
            X64.Out8(0x20, 0x11);
            X64.Out8(0xA0, 0x11);
            X64.Out8(0x21, 0x20);
            X64.Out8(0xA1, 40);
            X64.Out8(0x21, 0x04);
            X64.Out8(0xA1, 0x02);
            X64.Out8(0x21, 0x01);
            X64.Out8(0xA1, 0x01);
            X64.Out8(0x21, 0x0);
            X64.Out8(0xA1, 0x0);

            X64.Out8(0x21, 0xFD);
            X64.Out8(0xA1, 0xFF);
        }
    }
}
