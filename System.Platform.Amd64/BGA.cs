namespace System.Platform.Amd64
{
    /// <summary>
    /// Bochs VBE Extensions.
    /// Warning: This framebuffer device is only for virtual machine.
    /// Map the bar0 before use!
    /// </summary>
    public static unsafe class BGA
    {
        public static uint* Ptr;
        public static ushort Width, Height;
        public static ulong FrameSize;
        public static uint* Buffer;

        public static void Setup() 
        {
            for (ulong i = 0; i < PCI.Devices.Length; i++)
            {
                if (PCI.Devices[i].VendorID != 0x1234)
                    continue;

                Ptr = (uint*)PCI.Devices[i].Bar0;
                return;
            }
        }

        public static void Clear(uint color) 
        {
            Native.Stosb(Buffer, color, FrameSize);
        }

        public static void DrawPoint(int x, int y, uint color) 
        {
            if (x > 0 && y > 0)
                Buffer[Width * y + x] = color;
        }

        public static void Update() 
        {
            Native.Movsb(Ptr, Buffer, FrameSize);
        }

        public static void SetVideoMode(ushort width, ushort height)
        {
            Width = width;
            Height = height;
            FrameSize = (ulong)(Width * Height * 4);

            WriteRegister(4, 0);
            WriteRegister(1, width);
            WriteRegister(2, height);
            WriteRegister(3, 32);
            WriteRegister(4, 1 | 0x40);

            var p = stackalloc uint[(int)FrameSize];
            Buffer = p;
        }
        
        private static void WriteRegister(ushort index, ushort data)
        {
            Native.Out16(0x01CE, index);
            Native.Out16(0x01CF, data);
        }
    }
}
