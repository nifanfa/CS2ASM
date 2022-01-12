using static System.Runtime.Intrinsic;
using System.Platform.Amd64;

namespace ConsoleApp1
{
    /// <summary>
    /// Bochs VBE Extensions.
    /// Warning: This framebuffer device is only for virtual machine.
    /// Map the bar0 before use!
    /// </summary>
    public static unsafe class BGA
    {
        public static uint* Ptr;
        public static ushort Width;
        public static ushort Height;

        public static void Setup() 
        {
            for(ulong i = 0; i < PCI.Devices.Length; i++) 
            {
                if(PCI.Devices[i].VendorID == 0x1234) 
                {
                    Ptr = (uint*)PCI.Devices[i].Bar0;
                }
            }
        }

        public static void Clear(uint Color) 
        {
            x64.Stosd(Ptr, Color, (ulong)(Width * Height));
        }

        public static void DrawPoint(ushort X,ushort Y,uint Color) 
        {
            Ptr[Width * Y + X] = Color;
        }

        public static void WriteRegister(ushort IndexValue,ushort DataValue)
        {
            x64.Out16(0x01CE, IndexValue);
            x64.Out16(0x01CF, DataValue);
        }

        public static void SetVideoMode(ushort XRes, ushort YRes)
        {
            Width = XRes;
            Height = YRes;
            WriteRegister(4, 0);
            WriteRegister(1, XRes);
            WriteRegister(2, YRes);
            WriteRegister(3, 32);
            WriteRegister(4, (ushort)(1 | 0x40));
        }
    }
}
