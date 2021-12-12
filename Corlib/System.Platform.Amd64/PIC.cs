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
            
            //Clear Mask Of IRQ21(PS/2 Keyboard Interrupt)
            x64.Out8(0x21, 0xFD);
            x64.Out8(0xA1, 0xFF);
        }

        public static void EOI(uint irq)
        {
            if (irq >= 40)
                x64.Out8(0xA0, 0x20);

            x64.Out8(0x20, 0x20);
        }
    }
}
