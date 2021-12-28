namespace System.Platform.Amd64
{
    public class PCIDevice
    {
        public ushort Bus;
        public ushort Slot;
        public ushort Function;
        public ushort VendorID;
        public byte ClassID;
        public byte SubClassID;
        public uint Bar0;
    }

    public static unsafe class PCI
    {
        public static PCIDevice[] Devices = new PCIDevice[32];
        public static int index = 0;

        static PCI()
        {
            if (GetHeaderType(0, 0, 0) == 0)
            {
                CheckBus(0);

                for (int i = 0; i < index; i++)
                {
                    Console.Write("PCI Device:");
                    Console.Write("Bus:");
                    Console.Write(((ulong)Devices[i].Bus).ToString());
                    Console.Write(" ");
                    Console.Write("Slot:");
                    Console.Write(((ulong)Devices[i].Slot).ToString());
                    Console.Write(" ");
                    Console.Write("Func:");
                    Console.Write(((ulong)Devices[i].Function).ToString());
                    Console.Write(" ");
                    Console.Write("Bar0:0x");
                    Console.Write(((ulong)Devices[i].Bar0).ToString(16));
                    Console.Write(" ");
                    Console.Write("VendorID:0x");
                    Console.Write(((ulong)Devices[i].VendorID).ToString(16));
                    Console.WriteLine();
                }
            }
        }

        private static void CheckBus(ushort Bus)
        {
            for (ushort slot = 0; slot < 32; slot++)
            {
                ushort vendorID = GetVendorID(Bus, slot, 0);
                if (vendorID == 0xFFFF)
                {
                    continue;
                }

                PCIDevice device = new PCIDevice();
                device.Bus = Bus;
                device.Slot = slot;
                device.Function = 0;
                device.VendorID = vendorID;
                device.Bar0 = ReadRegister(device.Bus, device.Slot, device.Function, 16);
                device.ClassID = (byte)(ReadRegister(device.Bus, device.Slot, device.Function, 11) & 0xFF);
                device.ClassID = (byte)(ReadRegister(device.Bus, device.Slot, device.Function, 10) & 0xFF);

                Devices[index] = device;

                index++;

                if(device.ClassID == 0x06 && device.SubClassID == 0x04) 
                {
                    Console.WriteLine("TODO - This is a sub-PCI Controller");
                }
                continue; //Must exist
            }
        }

        public static uint ReadRegister(ushort Bus, ushort Slot, ushort Function, byte aRegister)
        {
            uint xAddr = PCI.GetAddressBase(Bus, Slot, Function) | ((uint)(aRegister & 0xFC));
            x64.Out32(0xCF8, xAddr);
            return x64.In32(0xCFC);
        }

        public static ushort GetVendorID(ushort Bus, ushort Slot, ushort Function)
        {
            uint xAddr = GetAddressBase(Bus, Slot, Function) | 0x0 & 0xFC;
            x64.Out32(0xCF8, xAddr);
            return (ushort)(x64.In32(0xCFC) >> ((0x0 % 4) * 8) & 0xFFFF);
        }

        public static ushort GetHeaderType(ushort Bus, ushort Slot, ushort Function)
        {
            uint xAddr = GetAddressBase(Bus, Slot, Function) | 0xE & 0xFC;
            x64.Out32(0xCF8, xAddr);
            return (byte)(x64.In32(0xCFC) >> ((0xE % 4) * 8) & 0xFF);
        }

        public static uint GetAddressBase(ushort Bus, uint Slot, uint Function)
        {
            return (uint)(0x80000000 | (Bus << 16) | ((Slot & 0x1F) << 11) | ((Function & 0x07) << 8));
        }
    }
}
