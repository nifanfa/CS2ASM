using System;
using System.Runtime.CompilerServices;
using static System.Runtime.CompilerServices.Unsafe;

namespace System.Platform.Amd64
{
    public static unsafe class IDT
    {
        private struct IDTEntry
        {
            public ushort BaseLow;
            public ushort Selector;
            public byte Reserved0;
            public byte TypeAttributes;
            public ushort BaseMid;
            public uint BaseHigh;
            public uint Reserved1;
        }

        private struct IDTDescriptor
        {
            public ushort Limit;
            public ulong Base;
        }

        static IDT()
        {
            IDTEntry* Entries = stackalloc IDTEntry[256];

            Set(Entries, 0, (uint)(delegate*<void>)(&IRQ0), 0x08, 0x8E);
            Set(Entries, 1, (uint)(delegate*<void>)(&IRQ1), 0x08, 0x8E);
            Set(Entries, 2, (uint)(delegate*<void>)(&IRQ2), 0x08, 0x8E);
            Set(Entries, 3, (uint)(delegate*<void>)(&IRQ3), 0x08, 0x8E);
            Set(Entries, 4, (uint)(delegate*<void>)(&IRQ4), 0x08, 0x8E);
            Set(Entries, 5, (uint)(delegate*<void>)(&IRQ5), 0x08, 0x8E);
            Set(Entries, 6, (uint)(delegate*<void>)(&IRQ6), 0x08, 0x8E);
            Set(Entries, 7, (uint)(delegate*<void>)(&IRQ7), 0x08, 0x8E);
            Set(Entries, 8, (uint)(delegate*<void>)(&IRQ8), 0x08, 0x8E);
            Set(Entries, 9, (uint)(delegate*<void>)(&IRQ9), 0x08, 0x8E);
            Set(Entries, 10, (uint)(delegate*<void>)(&IRQ10), 0x08, 0x8E);
            Set(Entries, 11, (uint)(delegate*<void>)(&IRQ11), 0x08, 0x8E);
            Set(Entries, 12, (uint)(delegate*<void>)(&IRQ12), 0x08, 0x8E);
            Set(Entries, 13, (uint)(delegate*<void>)(&IRQ13), 0x08, 0x8E);
            Set(Entries, 14, (uint)(delegate*<void>)(&IRQ14), 0x08, 0x8E);
            Set(Entries, 15, (uint)(delegate*<void>)(&IRQ15), 0x08, 0x8E);
            Set(Entries, 16, (uint)(delegate*<void>)(&IRQ16), 0x08, 0x8E);
            Set(Entries, 17, (uint)(delegate*<void>)(&IRQ17), 0x08, 0x8E);
            Set(Entries, 18, (uint)(delegate*<void>)(&IRQ18), 0x08, 0x8E);
            Set(Entries, 19, (uint)(delegate*<void>)(&IRQ19), 0x08, 0x8E);
            Set(Entries, 20, (uint)(delegate*<void>)(&IRQ20), 0x08, 0x8E);
            Set(Entries, 21, (uint)(delegate*<void>)(&IRQ21), 0x08, 0x8E);
            Set(Entries, 22, (uint)(delegate*<void>)(&IRQ22), 0x08, 0x8E);
            Set(Entries, 23, (uint)(delegate*<void>)(&IRQ23), 0x08, 0x8E);
            Set(Entries, 24, (uint)(delegate*<void>)(&IRQ24), 0x08, 0x8E);
            Set(Entries, 25, (uint)(delegate*<void>)(&IRQ25), 0x08, 0x8E);
            Set(Entries, 26, (uint)(delegate*<void>)(&IRQ26), 0x08, 0x8E);
            Set(Entries, 27, (uint)(delegate*<void>)(&IRQ27), 0x08, 0x8E);
            Set(Entries, 28, (uint)(delegate*<void>)(&IRQ28), 0x08, 0x8E);
            Set(Entries, 29, (uint)(delegate*<void>)(&IRQ29), 0x08, 0x8E);
            Set(Entries, 30, (uint)(delegate*<void>)(&IRQ30), 0x08, 0x8E);
            Set(Entries, 31, (uint)(delegate*<void>)(&IRQ31), 0x08, 0x8E);
            Set(Entries, 32, (uint)(delegate*<void>)(&IRQ32), 0x08, 0x8E);
            Set(Entries, 33, (uint)(delegate*<void>)(&IRQ33), 0x08, 0x8E);
            Set(Entries, 34, (uint)(delegate*<void>)(&IRQ34), 0x08, 0x8E);
            Set(Entries, 35, (uint)(delegate*<void>)(&IRQ35), 0x08, 0x8E);
            Set(Entries, 36, (uint)(delegate*<void>)(&IRQ36), 0x08, 0x8E);
            Set(Entries, 37, (uint)(delegate*<void>)(&IRQ37), 0x08, 0x8E);
            Set(Entries, 38, (uint)(delegate*<void>)(&IRQ38), 0x08, 0x8E);
            Set(Entries, 39, (uint)(delegate*<void>)(&IRQ39), 0x08, 0x8E);
            Set(Entries, 40, (uint)(delegate*<void>)(&IRQ40), 0x08, 0x8E);
            Set(Entries, 41, (uint)(delegate*<void>)(&IRQ41), 0x08, 0x8E);
            Set(Entries, 42, (uint)(delegate*<void>)(&IRQ42), 0x08, 0x8E);
            Set(Entries, 43, (uint)(delegate*<void>)(&IRQ43), 0x08, 0x8E);
            Set(Entries, 44, (uint)(delegate*<void>)(&IRQ44), 0x08, 0x8E);
            Set(Entries, 45, (uint)(delegate*<void>)(&IRQ45), 0x08, 0x8E);
            Set(Entries, 46, (uint)(delegate*<void>)(&IRQ46), 0x08, 0x8E);
            Set(Entries, 47, (uint)(delegate*<void>)(&IRQ47), 0x08, 0x8E);
            Set(Entries, 48, (uint)(delegate*<void>)(&IRQ48), 0x08, 0x8E);
            Set(Entries, 49, (uint)(delegate*<void>)(&IRQ49), 0x08, 0x8E);
            Set(Entries, 50, (uint)(delegate*<void>)(&IRQ50), 0x08, 0x8E);
            Set(Entries, 51, (uint)(delegate*<void>)(&IRQ51), 0x08, 0x8E);
            Set(Entries, 52, (uint)(delegate*<void>)(&IRQ52), 0x08, 0x8E);
            Set(Entries, 53, (uint)(delegate*<void>)(&IRQ53), 0x08, 0x8E);
            Set(Entries, 54, (uint)(delegate*<void>)(&IRQ54), 0x08, 0x8E);
            Set(Entries, 55, (uint)(delegate*<void>)(&IRQ55), 0x08, 0x8E);
            Set(Entries, 56, (uint)(delegate*<void>)(&IRQ56), 0x08, 0x8E);
            Set(Entries, 57, (uint)(delegate*<void>)(&IRQ57), 0x08, 0x8E);
            Set(Entries, 58, (uint)(delegate*<void>)(&IRQ58), 0x08, 0x8E);
            Set(Entries, 59, (uint)(delegate*<void>)(&IRQ59), 0x08, 0x8E);
            Set(Entries, 60, (uint)(delegate*<void>)(&IRQ60), 0x08, 0x8E);
            Set(Entries, 61, (uint)(delegate*<void>)(&IRQ61), 0x08, 0x8E);
            Set(Entries, 62, (uint)(delegate*<void>)(&IRQ62), 0x08, 0x8E);
            Set(Entries, 63, (uint)(delegate*<void>)(&IRQ63), 0x08, 0x8E);
            Set(Entries, 64, (uint)(delegate*<void>)(&IRQ64), 0x08, 0x8E);
            Set(Entries, 65, (uint)(delegate*<void>)(&IRQ65), 0x08, 0x8E);
            Set(Entries, 66, (uint)(delegate*<void>)(&IRQ66), 0x08, 0x8E);
            Set(Entries, 67, (uint)(delegate*<void>)(&IRQ67), 0x08, 0x8E);
            Set(Entries, 68, (uint)(delegate*<void>)(&IRQ68), 0x08, 0x8E);
            Set(Entries, 69, (uint)(delegate*<void>)(&IRQ69), 0x08, 0x8E);
            Set(Entries, 70, (uint)(delegate*<void>)(&IRQ70), 0x08, 0x8E);
            Set(Entries, 71, (uint)(delegate*<void>)(&IRQ71), 0x08, 0x8E);
            Set(Entries, 72, (uint)(delegate*<void>)(&IRQ72), 0x08, 0x8E);
            Set(Entries, 73, (uint)(delegate*<void>)(&IRQ73), 0x08, 0x8E);
            Set(Entries, 74, (uint)(delegate*<void>)(&IRQ74), 0x08, 0x8E);
            Set(Entries, 75, (uint)(delegate*<void>)(&IRQ75), 0x08, 0x8E);
            Set(Entries, 76, (uint)(delegate*<void>)(&IRQ76), 0x08, 0x8E);
            Set(Entries, 77, (uint)(delegate*<void>)(&IRQ77), 0x08, 0x8E);
            Set(Entries, 78, (uint)(delegate*<void>)(&IRQ78), 0x08, 0x8E);
            Set(Entries, 79, (uint)(delegate*<void>)(&IRQ79), 0x08, 0x8E);
            Set(Entries, 80, (uint)(delegate*<void>)(&IRQ80), 0x08, 0x8E);
            Set(Entries, 81, (uint)(delegate*<void>)(&IRQ81), 0x08, 0x8E);
            Set(Entries, 82, (uint)(delegate*<void>)(&IRQ82), 0x08, 0x8E);
            Set(Entries, 83, (uint)(delegate*<void>)(&IRQ83), 0x08, 0x8E);
            Set(Entries, 84, (uint)(delegate*<void>)(&IRQ84), 0x08, 0x8E);
            Set(Entries, 85, (uint)(delegate*<void>)(&IRQ85), 0x08, 0x8E);
            Set(Entries, 86, (uint)(delegate*<void>)(&IRQ86), 0x08, 0x8E);
            Set(Entries, 87, (uint)(delegate*<void>)(&IRQ87), 0x08, 0x8E);
            Set(Entries, 88, (uint)(delegate*<void>)(&IRQ88), 0x08, 0x8E);
            Set(Entries, 89, (uint)(delegate*<void>)(&IRQ89), 0x08, 0x8E);
            Set(Entries, 90, (uint)(delegate*<void>)(&IRQ90), 0x08, 0x8E);
            Set(Entries, 91, (uint)(delegate*<void>)(&IRQ91), 0x08, 0x8E);
            Set(Entries, 92, (uint)(delegate*<void>)(&IRQ92), 0x08, 0x8E);
            Set(Entries, 93, (uint)(delegate*<void>)(&IRQ93), 0x08, 0x8E);
            Set(Entries, 94, (uint)(delegate*<void>)(&IRQ94), 0x08, 0x8E);
            Set(Entries, 95, (uint)(delegate*<void>)(&IRQ95), 0x08, 0x8E);
            Set(Entries, 96, (uint)(delegate*<void>)(&IRQ96), 0x08, 0x8E);
            Set(Entries, 97, (uint)(delegate*<void>)(&IRQ97), 0x08, 0x8E);
            Set(Entries, 98, (uint)(delegate*<void>)(&IRQ98), 0x08, 0x8E);
            Set(Entries, 99, (uint)(delegate*<void>)(&IRQ99), 0x08, 0x8E);
            Set(Entries, 100, (uint)(delegate*<void>)(&IRQ100), 0x08, 0x8E);
            Set(Entries, 101, (uint)(delegate*<void>)(&IRQ101), 0x08, 0x8E);
            Set(Entries, 102, (uint)(delegate*<void>)(&IRQ102), 0x08, 0x8E);
            Set(Entries, 103, (uint)(delegate*<void>)(&IRQ103), 0x08, 0x8E);
            Set(Entries, 104, (uint)(delegate*<void>)(&IRQ104), 0x08, 0x8E);
            Set(Entries, 105, (uint)(delegate*<void>)(&IRQ105), 0x08, 0x8E);
            Set(Entries, 106, (uint)(delegate*<void>)(&IRQ106), 0x08, 0x8E);
            Set(Entries, 107, (uint)(delegate*<void>)(&IRQ107), 0x08, 0x8E);
            Set(Entries, 108, (uint)(delegate*<void>)(&IRQ108), 0x08, 0x8E);
            Set(Entries, 109, (uint)(delegate*<void>)(&IRQ109), 0x08, 0x8E);
            Set(Entries, 110, (uint)(delegate*<void>)(&IRQ110), 0x08, 0x8E);
            Set(Entries, 111, (uint)(delegate*<void>)(&IRQ111), 0x08, 0x8E);
            Set(Entries, 112, (uint)(delegate*<void>)(&IRQ112), 0x08, 0x8E);
            Set(Entries, 113, (uint)(delegate*<void>)(&IRQ113), 0x08, 0x8E);
            Set(Entries, 114, (uint)(delegate*<void>)(&IRQ114), 0x08, 0x8E);
            Set(Entries, 115, (uint)(delegate*<void>)(&IRQ115), 0x08, 0x8E);
            Set(Entries, 116, (uint)(delegate*<void>)(&IRQ116), 0x08, 0x8E);
            Set(Entries, 117, (uint)(delegate*<void>)(&IRQ117), 0x08, 0x8E);
            Set(Entries, 118, (uint)(delegate*<void>)(&IRQ118), 0x08, 0x8E);
            Set(Entries, 119, (uint)(delegate*<void>)(&IRQ119), 0x08, 0x8E);
            Set(Entries, 120, (uint)(delegate*<void>)(&IRQ120), 0x08, 0x8E);
            Set(Entries, 121, (uint)(delegate*<void>)(&IRQ121), 0x08, 0x8E);
            Set(Entries, 122, (uint)(delegate*<void>)(&IRQ122), 0x08, 0x8E);
            Set(Entries, 123, (uint)(delegate*<void>)(&IRQ123), 0x08, 0x8E);
            Set(Entries, 124, (uint)(delegate*<void>)(&IRQ124), 0x08, 0x8E);
            Set(Entries, 125, (uint)(delegate*<void>)(&IRQ125), 0x08, 0x8E);
            Set(Entries, 126, (uint)(delegate*<void>)(&IRQ126), 0x08, 0x8E);
            Set(Entries, 127, (uint)(delegate*<void>)(&IRQ127), 0x08, 0x8E);
            Set(Entries, 128, (uint)(delegate*<void>)(&IRQ128), 0x08, 0x8E);
            Set(Entries, 129, (uint)(delegate*<void>)(&IRQ129), 0x08, 0x8E);
            Set(Entries, 130, (uint)(delegate*<void>)(&IRQ130), 0x08, 0x8E);
            Set(Entries, 131, (uint)(delegate*<void>)(&IRQ131), 0x08, 0x8E);
            Set(Entries, 132, (uint)(delegate*<void>)(&IRQ132), 0x08, 0x8E);
            Set(Entries, 133, (uint)(delegate*<void>)(&IRQ133), 0x08, 0x8E);
            Set(Entries, 134, (uint)(delegate*<void>)(&IRQ134), 0x08, 0x8E);
            Set(Entries, 135, (uint)(delegate*<void>)(&IRQ135), 0x08, 0x8E);
            Set(Entries, 136, (uint)(delegate*<void>)(&IRQ136), 0x08, 0x8E);
            Set(Entries, 137, (uint)(delegate*<void>)(&IRQ137), 0x08, 0x8E);
            Set(Entries, 138, (uint)(delegate*<void>)(&IRQ138), 0x08, 0x8E);
            Set(Entries, 139, (uint)(delegate*<void>)(&IRQ139), 0x08, 0x8E);
            Set(Entries, 140, (uint)(delegate*<void>)(&IRQ140), 0x08, 0x8E);
            Set(Entries, 141, (uint)(delegate*<void>)(&IRQ141), 0x08, 0x8E);
            Set(Entries, 142, (uint)(delegate*<void>)(&IRQ142), 0x08, 0x8E);
            Set(Entries, 143, (uint)(delegate*<void>)(&IRQ143), 0x08, 0x8E);
            Set(Entries, 144, (uint)(delegate*<void>)(&IRQ144), 0x08, 0x8E);
            Set(Entries, 145, (uint)(delegate*<void>)(&IRQ145), 0x08, 0x8E);
            Set(Entries, 146, (uint)(delegate*<void>)(&IRQ146), 0x08, 0x8E);
            Set(Entries, 147, (uint)(delegate*<void>)(&IRQ147), 0x08, 0x8E);
            Set(Entries, 148, (uint)(delegate*<void>)(&IRQ148), 0x08, 0x8E);
            Set(Entries, 149, (uint)(delegate*<void>)(&IRQ149), 0x08, 0x8E);
            Set(Entries, 150, (uint)(delegate*<void>)(&IRQ150), 0x08, 0x8E);
            Set(Entries, 151, (uint)(delegate*<void>)(&IRQ151), 0x08, 0x8E);
            Set(Entries, 152, (uint)(delegate*<void>)(&IRQ152), 0x08, 0x8E);
            Set(Entries, 153, (uint)(delegate*<void>)(&IRQ153), 0x08, 0x8E);
            Set(Entries, 154, (uint)(delegate*<void>)(&IRQ154), 0x08, 0x8E);
            Set(Entries, 155, (uint)(delegate*<void>)(&IRQ155), 0x08, 0x8E);
            Set(Entries, 156, (uint)(delegate*<void>)(&IRQ156), 0x08, 0x8E);
            Set(Entries, 157, (uint)(delegate*<void>)(&IRQ157), 0x08, 0x8E);
            Set(Entries, 158, (uint)(delegate*<void>)(&IRQ158), 0x08, 0x8E);
            Set(Entries, 159, (uint)(delegate*<void>)(&IRQ159), 0x08, 0x8E);
            Set(Entries, 160, (uint)(delegate*<void>)(&IRQ160), 0x08, 0x8E);
            Set(Entries, 161, (uint)(delegate*<void>)(&IRQ161), 0x08, 0x8E);
            Set(Entries, 162, (uint)(delegate*<void>)(&IRQ162), 0x08, 0x8E);
            Set(Entries, 163, (uint)(delegate*<void>)(&IRQ163), 0x08, 0x8E);
            Set(Entries, 164, (uint)(delegate*<void>)(&IRQ164), 0x08, 0x8E);
            Set(Entries, 165, (uint)(delegate*<void>)(&IRQ165), 0x08, 0x8E);
            Set(Entries, 166, (uint)(delegate*<void>)(&IRQ166), 0x08, 0x8E);
            Set(Entries, 167, (uint)(delegate*<void>)(&IRQ167), 0x08, 0x8E);
            Set(Entries, 168, (uint)(delegate*<void>)(&IRQ168), 0x08, 0x8E);
            Set(Entries, 169, (uint)(delegate*<void>)(&IRQ169), 0x08, 0x8E);
            Set(Entries, 170, (uint)(delegate*<void>)(&IRQ170), 0x08, 0x8E);
            Set(Entries, 171, (uint)(delegate*<void>)(&IRQ171), 0x08, 0x8E);
            Set(Entries, 172, (uint)(delegate*<void>)(&IRQ172), 0x08, 0x8E);
            Set(Entries, 173, (uint)(delegate*<void>)(&IRQ173), 0x08, 0x8E);
            Set(Entries, 174, (uint)(delegate*<void>)(&IRQ174), 0x08, 0x8E);
            Set(Entries, 175, (uint)(delegate*<void>)(&IRQ175), 0x08, 0x8E);
            Set(Entries, 176, (uint)(delegate*<void>)(&IRQ176), 0x08, 0x8E);
            Set(Entries, 177, (uint)(delegate*<void>)(&IRQ177), 0x08, 0x8E);
            Set(Entries, 178, (uint)(delegate*<void>)(&IRQ178), 0x08, 0x8E);
            Set(Entries, 179, (uint)(delegate*<void>)(&IRQ179), 0x08, 0x8E);
            Set(Entries, 180, (uint)(delegate*<void>)(&IRQ180), 0x08, 0x8E);
            Set(Entries, 181, (uint)(delegate*<void>)(&IRQ181), 0x08, 0x8E);
            Set(Entries, 182, (uint)(delegate*<void>)(&IRQ182), 0x08, 0x8E);
            Set(Entries, 183, (uint)(delegate*<void>)(&IRQ183), 0x08, 0x8E);
            Set(Entries, 184, (uint)(delegate*<void>)(&IRQ184), 0x08, 0x8E);
            Set(Entries, 185, (uint)(delegate*<void>)(&IRQ185), 0x08, 0x8E);
            Set(Entries, 186, (uint)(delegate*<void>)(&IRQ186), 0x08, 0x8E);
            Set(Entries, 187, (uint)(delegate*<void>)(&IRQ187), 0x08, 0x8E);
            Set(Entries, 188, (uint)(delegate*<void>)(&IRQ188), 0x08, 0x8E);
            Set(Entries, 189, (uint)(delegate*<void>)(&IRQ189), 0x08, 0x8E);
            Set(Entries, 190, (uint)(delegate*<void>)(&IRQ190), 0x08, 0x8E);
            Set(Entries, 191, (uint)(delegate*<void>)(&IRQ191), 0x08, 0x8E);
            Set(Entries, 192, (uint)(delegate*<void>)(&IRQ192), 0x08, 0x8E);
            Set(Entries, 193, (uint)(delegate*<void>)(&IRQ193), 0x08, 0x8E);
            Set(Entries, 194, (uint)(delegate*<void>)(&IRQ194), 0x08, 0x8E);
            Set(Entries, 195, (uint)(delegate*<void>)(&IRQ195), 0x08, 0x8E);
            Set(Entries, 196, (uint)(delegate*<void>)(&IRQ196), 0x08, 0x8E);
            Set(Entries, 197, (uint)(delegate*<void>)(&IRQ197), 0x08, 0x8E);
            Set(Entries, 198, (uint)(delegate*<void>)(&IRQ198), 0x08, 0x8E);
            Set(Entries, 199, (uint)(delegate*<void>)(&IRQ199), 0x08, 0x8E);
            Set(Entries, 200, (uint)(delegate*<void>)(&IRQ200), 0x08, 0x8E);
            Set(Entries, 201, (uint)(delegate*<void>)(&IRQ201), 0x08, 0x8E);
            Set(Entries, 202, (uint)(delegate*<void>)(&IRQ202), 0x08, 0x8E);
            Set(Entries, 203, (uint)(delegate*<void>)(&IRQ203), 0x08, 0x8E);
            Set(Entries, 204, (uint)(delegate*<void>)(&IRQ204), 0x08, 0x8E);
            Set(Entries, 205, (uint)(delegate*<void>)(&IRQ205), 0x08, 0x8E);
            Set(Entries, 206, (uint)(delegate*<void>)(&IRQ206), 0x08, 0x8E);
            Set(Entries, 207, (uint)(delegate*<void>)(&IRQ207), 0x08, 0x8E);
            Set(Entries, 208, (uint)(delegate*<void>)(&IRQ208), 0x08, 0x8E);
            Set(Entries, 209, (uint)(delegate*<void>)(&IRQ209), 0x08, 0x8E);
            Set(Entries, 210, (uint)(delegate*<void>)(&IRQ210), 0x08, 0x8E);
            Set(Entries, 211, (uint)(delegate*<void>)(&IRQ211), 0x08, 0x8E);
            Set(Entries, 212, (uint)(delegate*<void>)(&IRQ212), 0x08, 0x8E);
            Set(Entries, 213, (uint)(delegate*<void>)(&IRQ213), 0x08, 0x8E);
            Set(Entries, 214, (uint)(delegate*<void>)(&IRQ214), 0x08, 0x8E);
            Set(Entries, 215, (uint)(delegate*<void>)(&IRQ215), 0x08, 0x8E);
            Set(Entries, 216, (uint)(delegate*<void>)(&IRQ216), 0x08, 0x8E);
            Set(Entries, 217, (uint)(delegate*<void>)(&IRQ217), 0x08, 0x8E);
            Set(Entries, 218, (uint)(delegate*<void>)(&IRQ218), 0x08, 0x8E);
            Set(Entries, 219, (uint)(delegate*<void>)(&IRQ219), 0x08, 0x8E);
            Set(Entries, 220, (uint)(delegate*<void>)(&IRQ220), 0x08, 0x8E);
            Set(Entries, 221, (uint)(delegate*<void>)(&IRQ221), 0x08, 0x8E);
            Set(Entries, 222, (uint)(delegate*<void>)(&IRQ222), 0x08, 0x8E);
            Set(Entries, 223, (uint)(delegate*<void>)(&IRQ223), 0x08, 0x8E);
            Set(Entries, 224, (uint)(delegate*<void>)(&IRQ224), 0x08, 0x8E);
            Set(Entries, 225, (uint)(delegate*<void>)(&IRQ225), 0x08, 0x8E);
            Set(Entries, 226, (uint)(delegate*<void>)(&IRQ226), 0x08, 0x8E);
            Set(Entries, 227, (uint)(delegate*<void>)(&IRQ227), 0x08, 0x8E);
            Set(Entries, 228, (uint)(delegate*<void>)(&IRQ228), 0x08, 0x8E);
            Set(Entries, 229, (uint)(delegate*<void>)(&IRQ229), 0x08, 0x8E);
            Set(Entries, 230, (uint)(delegate*<void>)(&IRQ230), 0x08, 0x8E);
            Set(Entries, 231, (uint)(delegate*<void>)(&IRQ231), 0x08, 0x8E);
            Set(Entries, 232, (uint)(delegate*<void>)(&IRQ232), 0x08, 0x8E);
            Set(Entries, 233, (uint)(delegate*<void>)(&IRQ233), 0x08, 0x8E);
            Set(Entries, 234, (uint)(delegate*<void>)(&IRQ234), 0x08, 0x8E);
            Set(Entries, 235, (uint)(delegate*<void>)(&IRQ235), 0x08, 0x8E);
            Set(Entries, 236, (uint)(delegate*<void>)(&IRQ236), 0x08, 0x8E);
            Set(Entries, 237, (uint)(delegate*<void>)(&IRQ237), 0x08, 0x8E);
            Set(Entries, 238, (uint)(delegate*<void>)(&IRQ238), 0x08, 0x8E);
            Set(Entries, 239, (uint)(delegate*<void>)(&IRQ239), 0x08, 0x8E);
            Set(Entries, 240, (uint)(delegate*<void>)(&IRQ240), 0x08, 0x8E);
            Set(Entries, 241, (uint)(delegate*<void>)(&IRQ241), 0x08, 0x8E);
            Set(Entries, 242, (uint)(delegate*<void>)(&IRQ242), 0x08, 0x8E);
            Set(Entries, 243, (uint)(delegate*<void>)(&IRQ243), 0x08, 0x8E);
            Set(Entries, 244, (uint)(delegate*<void>)(&IRQ244), 0x08, 0x8E);
            Set(Entries, 245, (uint)(delegate*<void>)(&IRQ245), 0x08, 0x8E);
            Set(Entries, 246, (uint)(delegate*<void>)(&IRQ246), 0x08, 0x8E);
            Set(Entries, 247, (uint)(delegate*<void>)(&IRQ247), 0x08, 0x8E);
            Set(Entries, 248, (uint)(delegate*<void>)(&IRQ248), 0x08, 0x8E);
            Set(Entries, 249, (uint)(delegate*<void>)(&IRQ249), 0x08, 0x8E);
            Set(Entries, 250, (uint)(delegate*<void>)(&IRQ250), 0x08, 0x8E);
            Set(Entries, 251, (uint)(delegate*<void>)(&IRQ251), 0x08, 0x8E);
            Set(Entries, 252, (uint)(delegate*<void>)(&IRQ252), 0x08, 0x8E);
            Set(Entries, 253, (uint)(delegate*<void>)(&IRQ253), 0x08, 0x8E);
            Set(Entries, 254, (uint)(delegate*<void>)(&IRQ254), 0x08, 0x8E);
            Set(Entries, 255, (uint)(delegate*<void>)(&IRQ255), 0x08, 0x8E);

            IDTDescriptor* Descriptor = stackalloc IDTDescriptor[1];
            Descriptor->Limit = (ushort)((sizeof(IDTEntry) * 256) - 1);
            Descriptor->Base = (ulong)Entries;

            asm("mov rax,{Descriptor}");
            asm("lidt [rax]");

            PIC.Enable();
        }


        private static void Set(IDTEntry* Entry, int Index, uint Base, ushort Selector, byte TypeAttribute)
        {
            (&Entry[Index])->BaseLow = (ushort)(Base & 0xFFFF);
            (&Entry[Index])->BaseMid = (ushort)((Base >> 16) & 0xFFFF);
            (&Entry[Index])->BaseHigh = 0;
            (&Entry[Index])->Selector = Selector;
            (&Entry[Index])->TypeAttributes = TypeAttribute;
            (&Entry[Index])->Reserved0 = 0;
            (&Entry[Index])->Reserved1 = 0;
        }

        private static void OnInterrupt(ulong irq)
        {
            if (irq < 32)
            {
                if(irq == 0x0E) 
                {
                    ulong cr2 = 0;
                    asm("mov rax,cr2");
                    asm("mov {cr2},rax");
                    if ((cr2 >> 5) < 0x1000)
                    {
                        Console.WriteLine("CPU Exception: Null Reference Exception!");
                    }
                }
                else
                {
                    Console.Write("CPU Exception: 0x");
                    Console.Write(irq.ToString("x2"));
                    Console.WriteLine(" System Halted!");
                }
                asm("jmp $");
            }
            if (irq == 0x20)
            {
                PIT.OnInterrupt();
            }
            if (irq == 0x21)
            {
                PS2Keyboard.OnInterrupt();
            }
            if (irq == 0x2C)
            {
                PS2Mouse.OnInterrupt();
            }

            PIC.EndOfInterrupt(irq);
        }

        [AssemblyMethod]
        private static void IRQ0()
        {
            asm("pushaq");
            asm("mov qword rdi,0"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ1()
        {
            asm("pushaq");
            asm("mov qword rdi,1"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ2()
        {
            asm("pushaq");
            asm("mov qword rdi,2"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ3()
        {
            asm("pushaq");
            asm("mov qword rdi,3"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ4()
        {
            asm("pushaq");
            asm("mov qword rdi,4"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ5()
        {
            asm("pushaq");
            asm("mov qword rdi,5"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ6()
        {
            asm("pushaq");
            asm("mov qword rdi,6"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ7()
        {
            asm("pushaq");
            asm("mov qword rdi,7"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ8()
        {
            asm("pushaq");
            asm("mov qword rdi,8"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ9()
        {
            asm("pushaq");
            asm("mov qword rdi,9"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ10()
        {
            asm("pushaq");
            asm("mov qword rdi,10"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ11()
        {
            asm("pushaq");
            asm("mov qword rdi,11"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ12()
        {
            asm("pushaq");
            asm("mov qword rdi,12"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ13()
        {
            asm("pushaq");
            asm("mov qword rdi,13"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ14()
        {
            asm("pushaq");
            asm("mov qword rdi,14"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ15()
        {
            asm("pushaq");
            asm("mov qword rdi,15"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ16()
        {
            asm("pushaq");
            asm("mov qword rdi,16"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ17()
        {
            asm("pushaq");
            asm("mov qword rdi,17"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ18()
        {
            asm("pushaq");
            asm("mov qword rdi,18"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ19()
        {
            asm("pushaq");
            asm("mov qword rdi,19"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ20()
        {
            asm("pushaq");
            asm("mov qword rdi,20"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ21()
        {
            asm("pushaq");
            asm("mov qword rdi,21"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ22()
        {
            asm("pushaq");
            asm("mov qword rdi,22"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ23()
        {
            asm("pushaq");
            asm("mov qword rdi,23"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ24()
        {
            asm("pushaq");
            asm("mov qword rdi,24"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ25()
        {
            asm("pushaq");
            asm("mov qword rdi,25"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ26()
        {
            asm("pushaq");
            asm("mov qword rdi,26"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ27()
        {
            asm("pushaq");
            asm("mov qword rdi,27"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ28()
        {
            asm("pushaq");
            asm("mov qword rdi,28"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ29()
        {
            asm("pushaq");
            asm("mov qword rdi,29"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ30()
        {
            asm("pushaq");
            asm("mov qword rdi,30"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ31()
        {
            asm("pushaq");
            asm("mov qword rdi,31"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ32()
        {
            asm("pushaq");
            asm("mov qword rdi,32"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ33()
        {
            asm("pushaq");
            asm("mov qword rdi,33"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ34()
        {
            asm("pushaq");
            asm("mov qword rdi,34"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ35()
        {
            asm("pushaq");
            asm("mov qword rdi,35"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ36()
        {
            asm("pushaq");
            asm("mov qword rdi,36"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ37()
        {
            asm("pushaq");
            asm("mov qword rdi,37"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ38()
        {
            asm("pushaq");
            asm("mov qword rdi,38"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ39()
        {
            asm("pushaq");
            asm("mov qword rdi,39"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ40()
        {
            asm("pushaq");
            asm("mov qword rdi,40"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ41()
        {
            asm("pushaq");
            asm("mov qword rdi,41"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ42()
        {
            asm("pushaq");
            asm("mov qword rdi,42"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ43()
        {
            asm("pushaq");
            asm("mov qword rdi,43"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ44()
        {
            asm("pushaq");
            asm("mov qword rdi,44"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ45()
        {
            asm("pushaq");
            asm("mov qword rdi,45"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ46()
        {
            asm("pushaq");
            asm("mov qword rdi,46"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ47()
        {
            asm("pushaq");
            asm("mov qword rdi,47"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ48()
        {
            asm("pushaq");
            asm("mov qword rdi,48"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ49()
        {
            asm("pushaq");
            asm("mov qword rdi,49"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ50()
        {
            asm("pushaq");
            asm("mov qword rdi,50"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ51()
        {
            asm("pushaq");
            asm("mov qword rdi,51"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ52()
        {
            asm("pushaq");
            asm("mov qword rdi,52"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ53()
        {
            asm("pushaq");
            asm("mov qword rdi,53"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ54()
        {
            asm("pushaq");
            asm("mov qword rdi,54"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ55()
        {
            asm("pushaq");
            asm("mov qword rdi,55"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ56()
        {
            asm("pushaq");
            asm("mov qword rdi,56"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ57()
        {
            asm("pushaq");
            asm("mov qword rdi,57"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ58()
        {
            asm("pushaq");
            asm("mov qword rdi,58"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ59()
        {
            asm("pushaq");
            asm("mov qword rdi,59"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ60()
        {
            asm("pushaq");
            asm("mov qword rdi,60"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ61()
        {
            asm("pushaq");
            asm("mov qword rdi,61"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ62()
        {
            asm("pushaq");
            asm("mov qword rdi,62"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ63()
        {
            asm("pushaq");
            asm("mov qword rdi,63"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ64()
        {
            asm("pushaq");
            asm("mov qword rdi,64"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ65()
        {
            asm("pushaq");
            asm("mov qword rdi,65"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ66()
        {
            asm("pushaq");
            asm("mov qword rdi,66"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ67()
        {
            asm("pushaq");
            asm("mov qword rdi,67"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ68()
        {
            asm("pushaq");
            asm("mov qword rdi,68"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ69()
        {
            asm("pushaq");
            asm("mov qword rdi,69"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ70()
        {
            asm("pushaq");
            asm("mov qword rdi,70"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ71()
        {
            asm("pushaq");
            asm("mov qword rdi,71"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ72()
        {
            asm("pushaq");
            asm("mov qword rdi,72"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ73()
        {
            asm("pushaq");
            asm("mov qword rdi,73"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ74()
        {
            asm("pushaq");
            asm("mov qword rdi,74"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ75()
        {
            asm("pushaq");
            asm("mov qword rdi,75"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ76()
        {
            asm("pushaq");
            asm("mov qword rdi,76"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ77()
        {
            asm("pushaq");
            asm("mov qword rdi,77"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ78()
        {
            asm("pushaq");
            asm("mov qword rdi,78"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ79()
        {
            asm("pushaq");
            asm("mov qword rdi,79"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ80()
        {
            asm("pushaq");
            asm("mov qword rdi,80"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ81()
        {
            asm("pushaq");
            asm("mov qword rdi,81"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ82()
        {
            asm("pushaq");
            asm("mov qword rdi,82"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ83()
        {
            asm("pushaq");
            asm("mov qword rdi,83"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ84()
        {
            asm("pushaq");
            asm("mov qword rdi,84"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ85()
        {
            asm("pushaq");
            asm("mov qword rdi,85"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ86()
        {
            asm("pushaq");
            asm("mov qword rdi,86"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ87()
        {
            asm("pushaq");
            asm("mov qword rdi,87"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ88()
        {
            asm("pushaq");
            asm("mov qword rdi,88"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ89()
        {
            asm("pushaq");
            asm("mov qword rdi,89"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ90()
        {
            asm("pushaq");
            asm("mov qword rdi,90"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ91()
        {
            asm("pushaq");
            asm("mov qword rdi,91"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ92()
        {
            asm("pushaq");
            asm("mov qword rdi,92"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ93()
        {
            asm("pushaq");
            asm("mov qword rdi,93"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ94()
        {
            asm("pushaq");
            asm("mov qword rdi,94"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ95()
        {
            asm("pushaq");
            asm("mov qword rdi,95"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ96()
        {
            asm("pushaq");
            asm("mov qword rdi,96"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ97()
        {
            asm("pushaq");
            asm("mov qword rdi,97"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ98()
        {
            asm("pushaq");
            asm("mov qword rdi,98"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ99()
        {
            asm("pushaq");
            asm("mov qword rdi,99"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ100()
        {
            asm("pushaq");
            asm("mov qword rdi,100"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ101()
        {
            asm("pushaq");
            asm("mov qword rdi,101"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ102()
        {
            asm("pushaq");
            asm("mov qword rdi,102"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ103()
        {
            asm("pushaq");
            asm("mov qword rdi,103"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ104()
        {
            asm("pushaq");
            asm("mov qword rdi,104"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ105()
        {
            asm("pushaq");
            asm("mov qword rdi,105"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ106()
        {
            asm("pushaq");
            asm("mov qword rdi,106"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ107()
        {
            asm("pushaq");
            asm("mov qword rdi,107"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ108()
        {
            asm("pushaq");
            asm("mov qword rdi,108"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ109()
        {
            asm("pushaq");
            asm("mov qword rdi,109"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ110()
        {
            asm("pushaq");
            asm("mov qword rdi,110"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ111()
        {
            asm("pushaq");
            asm("mov qword rdi,111"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ112()
        {
            asm("pushaq");
            asm("mov qword rdi,112"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ113()
        {
            asm("pushaq");
            asm("mov qword rdi,113"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ114()
        {
            asm("pushaq");
            asm("mov qword rdi,114"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ115()
        {
            asm("pushaq");
            asm("mov qword rdi,115"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ116()
        {
            asm("pushaq");
            asm("mov qword rdi,116"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ117()
        {
            asm("pushaq");
            asm("mov qword rdi,117"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ118()
        {
            asm("pushaq");
            asm("mov qword rdi,118"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ119()
        {
            asm("pushaq");
            asm("mov qword rdi,119"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ120()
        {
            asm("pushaq");
            asm("mov qword rdi,120"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ121()
        {
            asm("pushaq");
            asm("mov qword rdi,121"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ122()
        {
            asm("pushaq");
            asm("mov qword rdi,122"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ123()
        {
            asm("pushaq");
            asm("mov qword rdi,123"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ124()
        {
            asm("pushaq");
            asm("mov qword rdi,124"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ125()
        {
            asm("pushaq");
            asm("mov qword rdi,125"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ126()
        {
            asm("pushaq");
            asm("mov qword rdi,126"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ127()
        {
            asm("pushaq");
            asm("mov qword rdi,127"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ128()
        {
            asm("pushaq");
            asm("mov qword rdi,128"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ129()
        {
            asm("pushaq");
            asm("mov qword rdi,129"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ130()
        {
            asm("pushaq");
            asm("mov qword rdi,130"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ131()
        {
            asm("pushaq");
            asm("mov qword rdi,131"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ132()
        {
            asm("pushaq");
            asm("mov qword rdi,132"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ133()
        {
            asm("pushaq");
            asm("mov qword rdi,133"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ134()
        {
            asm("pushaq");
            asm("mov qword rdi,134"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ135()
        {
            asm("pushaq");
            asm("mov qword rdi,135"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ136()
        {
            asm("pushaq");
            asm("mov qword rdi,136"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ137()
        {
            asm("pushaq");
            asm("mov qword rdi,137"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ138()
        {
            asm("pushaq");
            asm("mov qword rdi,138"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ139()
        {
            asm("pushaq");
            asm("mov qword rdi,139"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ140()
        {
            asm("pushaq");
            asm("mov qword rdi,140"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ141()
        {
            asm("pushaq");
            asm("mov qword rdi,141"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ142()
        {
            asm("pushaq");
            asm("mov qword rdi,142"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ143()
        {
            asm("pushaq");
            asm("mov qword rdi,143"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ144()
        {
            asm("pushaq");
            asm("mov qword rdi,144"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ145()
        {
            asm("pushaq");
            asm("mov qword rdi,145"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ146()
        {
            asm("pushaq");
            asm("mov qword rdi,146"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ147()
        {
            asm("pushaq");
            asm("mov qword rdi,147"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ148()
        {
            asm("pushaq");
            asm("mov qword rdi,148"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ149()
        {
            asm("pushaq");
            asm("mov qword rdi,149"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ150()
        {
            asm("pushaq");
            asm("mov qword rdi,150"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ151()
        {
            asm("pushaq");
            asm("mov qword rdi,151"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ152()
        {
            asm("pushaq");
            asm("mov qword rdi,152"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ153()
        {
            asm("pushaq");
            asm("mov qword rdi,153"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ154()
        {
            asm("pushaq");
            asm("mov qword rdi,154"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ155()
        {
            asm("pushaq");
            asm("mov qword rdi,155"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ156()
        {
            asm("pushaq");
            asm("mov qword rdi,156"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ157()
        {
            asm("pushaq");
            asm("mov qword rdi,157"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ158()
        {
            asm("pushaq");
            asm("mov qword rdi,158"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ159()
        {
            asm("pushaq");
            asm("mov qword rdi,159"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ160()
        {
            asm("pushaq");
            asm("mov qword rdi,160"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ161()
        {
            asm("pushaq");
            asm("mov qword rdi,161"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ162()
        {
            asm("pushaq");
            asm("mov qword rdi,162"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ163()
        {
            asm("pushaq");
            asm("mov qword rdi,163"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ164()
        {
            asm("pushaq");
            asm("mov qword rdi,164"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ165()
        {
            asm("pushaq");
            asm("mov qword rdi,165"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ166()
        {
            asm("pushaq");
            asm("mov qword rdi,166"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ167()
        {
            asm("pushaq");
            asm("mov qword rdi,167"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ168()
        {
            asm("pushaq");
            asm("mov qword rdi,168"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ169()
        {
            asm("pushaq");
            asm("mov qword rdi,169"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ170()
        {
            asm("pushaq");
            asm("mov qword rdi,170"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ171()
        {
            asm("pushaq");
            asm("mov qword rdi,171"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ172()
        {
            asm("pushaq");
            asm("mov qword rdi,172"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ173()
        {
            asm("pushaq");
            asm("mov qword rdi,173"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ174()
        {
            asm("pushaq");
            asm("mov qword rdi,174"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ175()
        {
            asm("pushaq");
            asm("mov qword rdi,175"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ176()
        {
            asm("pushaq");
            asm("mov qword rdi,176"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ177()
        {
            asm("pushaq");
            asm("mov qword rdi,177"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ178()
        {
            asm("pushaq");
            asm("mov qword rdi,178"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ179()
        {
            asm("pushaq");
            asm("mov qword rdi,179"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ180()
        {
            asm("pushaq");
            asm("mov qword rdi,180"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ181()
        {
            asm("pushaq");
            asm("mov qword rdi,181"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ182()
        {
            asm("pushaq");
            asm("mov qword rdi,182"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ183()
        {
            asm("pushaq");
            asm("mov qword rdi,183"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ184()
        {
            asm("pushaq");
            asm("mov qword rdi,184"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ185()
        {
            asm("pushaq");
            asm("mov qword rdi,185"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ186()
        {
            asm("pushaq");
            asm("mov qword rdi,186"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ187()
        {
            asm("pushaq");
            asm("mov qword rdi,187"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ188()
        {
            asm("pushaq");
            asm("mov qword rdi,188"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ189()
        {
            asm("pushaq");
            asm("mov qword rdi,189"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ190()
        {
            asm("pushaq");
            asm("mov qword rdi,190"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ191()
        {
            asm("pushaq");
            asm("mov qword rdi,191"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ192()
        {
            asm("pushaq");
            asm("mov qword rdi,192"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ193()
        {
            asm("pushaq");
            asm("mov qword rdi,193"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ194()
        {
            asm("pushaq");
            asm("mov qword rdi,194"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ195()
        {
            asm("pushaq");
            asm("mov qword rdi,195"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ196()
        {
            asm("pushaq");
            asm("mov qword rdi,196"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ197()
        {
            asm("pushaq");
            asm("mov qword rdi,197"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ198()
        {
            asm("pushaq");
            asm("mov qword rdi,198"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ199()
        {
            asm("pushaq");
            asm("mov qword rdi,199"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ200()
        {
            asm("pushaq");
            asm("mov qword rdi,200"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ201()
        {
            asm("pushaq");
            asm("mov qword rdi,201"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ202()
        {
            asm("pushaq");
            asm("mov qword rdi,202"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ203()
        {
            asm("pushaq");
            asm("mov qword rdi,203"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ204()
        {
            asm("pushaq");
            asm("mov qword rdi,204"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ205()
        {
            asm("pushaq");
            asm("mov qword rdi,205"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ206()
        {
            asm("pushaq");
            asm("mov qword rdi,206"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ207()
        {
            asm("pushaq");
            asm("mov qword rdi,207"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ208()
        {
            asm("pushaq");
            asm("mov qword rdi,208"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ209()
        {
            asm("pushaq");
            asm("mov qword rdi,209"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ210()
        {
            asm("pushaq");
            asm("mov qword rdi,210"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ211()
        {
            asm("pushaq");
            asm("mov qword rdi,211"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ212()
        {
            asm("pushaq");
            asm("mov qword rdi,212"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ213()
        {
            asm("pushaq");
            asm("mov qword rdi,213"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ214()
        {
            asm("pushaq");
            asm("mov qword rdi,214"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ215()
        {
            asm("pushaq");
            asm("mov qword rdi,215"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ216()
        {
            asm("pushaq");
            asm("mov qword rdi,216"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ217()
        {
            asm("pushaq");
            asm("mov qword rdi,217"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ218()
        {
            asm("pushaq");
            asm("mov qword rdi,218"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ219()
        {
            asm("pushaq");
            asm("mov qword rdi,219"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ220()
        {
            asm("pushaq");
            asm("mov qword rdi,220"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ221()
        {
            asm("pushaq");
            asm("mov qword rdi,221"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ222()
        {
            asm("pushaq");
            asm("mov qword rdi,222"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ223()
        {
            asm("pushaq");
            asm("mov qword rdi,223"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ224()
        {
            asm("pushaq");
            asm("mov qword rdi,224"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ225()
        {
            asm("pushaq");
            asm("mov qword rdi,225"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ226()
        {
            asm("pushaq");
            asm("mov qword rdi,226"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ227()
        {
            asm("pushaq");
            asm("mov qword rdi,227"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ228()
        {
            asm("pushaq");
            asm("mov qword rdi,228"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ229()
        {
            asm("pushaq");
            asm("mov qword rdi,229"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ230()
        {
            asm("pushaq");
            asm("mov qword rdi,230"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ231()
        {
            asm("pushaq");
            asm("mov qword rdi,231"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ232()
        {
            asm("pushaq");
            asm("mov qword rdi,232"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ233()
        {
            asm("pushaq");
            asm("mov qword rdi,233"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ234()
        {
            asm("pushaq");
            asm("mov qword rdi,234"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ235()
        {
            asm("pushaq");
            asm("mov qword rdi,235"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ236()
        {
            asm("pushaq");
            asm("mov qword rdi,236"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ237()
        {
            asm("pushaq");
            asm("mov qword rdi,237"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ238()
        {
            asm("pushaq");
            asm("mov qword rdi,238"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ239()
        {
            asm("pushaq");
            asm("mov qword rdi,239"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ240()
        {
            asm("pushaq");
            asm("mov qword rdi,240"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ241()
        {
            asm("pushaq");
            asm("mov qword rdi,241"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ242()
        {
            asm("pushaq");
            asm("mov qword rdi,242"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ243()
        {
            asm("pushaq");
            asm("mov qword rdi,243"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ244()
        {
            asm("pushaq");
            asm("mov qword rdi,244"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ245()
        {
            asm("pushaq");
            asm("mov qword rdi,245"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ246()
        {
            asm("pushaq");
            asm("mov qword rdi,246"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ247()
        {
            asm("pushaq");
            asm("mov qword rdi,247"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ248()
        {
            asm("pushaq");
            asm("mov qword rdi,248"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ249()
        {
            asm("pushaq");
            asm("mov qword rdi,249"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ250()
        {
            asm("pushaq");
            asm("mov qword rdi,250"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ251()
        {
            asm("pushaq");
            asm("mov qword rdi,251"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ252()
        {
            asm("pushaq");
            asm("mov qword rdi,252"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ253()
        {
            asm("pushaq");
            asm("mov qword rdi,253"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ254()
        {
            asm("pushaq");
            asm("mov qword rdi,254"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }

        [AssemblyMethod]
        private static void IRQ255()
        {
            asm("pushaq");
            asm("mov qword rdi,255"); 
            asm("call System.Platform.Amd64.IDT.OnInterrupt_UInt64");
            asm("popaq");
            asm("iretq");
        }
    }
}
