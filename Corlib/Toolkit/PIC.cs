namespace Toolkit
{
    public static class PIC
    {
        public static void Enable()
        {
            IOPort.Out8(0x20, 0x11);
            IOPort.Out8(0xA0, 0x11);
            IOPort.Out8(0x21, 0x20);
            IOPort.Out8(0xA1, 40);
            IOPort.Out8(0x21, 0x04);
            IOPort.Out8(0xA1, 0x02);
            IOPort.Out8(0x21, 0x01);
            IOPort.Out8(0xA1, 0x01);
            IOPort.Out8(0x21, 0x0);
            IOPort.Out8(0xA1, 0x0);

            IOPort.Out8(0x21, 0xFD);
            IOPort.Out8(0xA1, 0xFF);
        }
    }
}
