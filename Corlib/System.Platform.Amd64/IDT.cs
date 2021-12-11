using System;
using System.Runtime.CompilerServices;
using static System.Runtime.Intrinsic;

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
            string s = "Interrupt:";
            Console.WriteStr(s, 7);
            Console.WriteStr(Convert.ToString(irq), 8);

            if (irq == 0x21)
            {
                PS2Keyboard.OnInterrupt();
            }

            byte tempColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.LightCyan;
            Console.WriteAt(PS2Keyboard.KeyPressed, 0, 24);
            Console.ForegroundColor = tempColor;
        }

        [EmptyMethod]
        private static void IRQ0() => asm("procirq 0");

        [EmptyMethod]
        private static void IRQ1() => asm("procirq 1");

        [EmptyMethod]
        private static void IRQ2() => asm("procirq 2");

        [EmptyMethod]
        private static void IRQ3() => asm("procirq 3");

        [EmptyMethod]
        private static void IRQ4() => asm("procirq 4");

        [EmptyMethod]
        private static void IRQ5() => asm("procirq 5");

        [EmptyMethod]
        private static void IRQ6() => asm("procirq 6");

        [EmptyMethod]
        private static void IRQ7() => asm("procirq 7");

        [EmptyMethod]
        private static void IRQ8() => asm("procirq 8");

        [EmptyMethod]
        private static void IRQ9() => asm("procirq 9");

        [EmptyMethod]
        private static void IRQ10() => asm("procirq 10");

        [EmptyMethod]
        private static void IRQ11() => asm("procirq 11");

        [EmptyMethod]
        private static void IRQ12() => asm("procirq 12");

        [EmptyMethod]
        private static void IRQ13() => asm("procirq 13");

        [EmptyMethod]
        private static void IRQ14() => asm("procirq 14");

        [EmptyMethod]
        private static void IRQ15() => asm("procirq 15");

        [EmptyMethod]
        private static void IRQ16() => asm("procirq 16");

        [EmptyMethod]
        private static void IRQ17() => asm("procirq 17");

        [EmptyMethod]
        private static void IRQ18() => asm("procirq 18");

        [EmptyMethod]
        private static void IRQ19() => asm("procirq 19");

        [EmptyMethod]
        private static void IRQ20() => asm("procirq 20");

        [EmptyMethod]
        private static void IRQ21() => asm("procirq 21");

        [EmptyMethod]
        private static void IRQ22() => asm("procirq 22");

        [EmptyMethod]
        private static void IRQ23() => asm("procirq 23");

        [EmptyMethod]
        private static void IRQ24() => asm("procirq 24");

        [EmptyMethod]
        private static void IRQ25() => asm("procirq 25");

        [EmptyMethod]
        private static void IRQ26() => asm("procirq 26");

        [EmptyMethod]
        private static void IRQ27() => asm("procirq 27");

        [EmptyMethod]
        private static void IRQ28() => asm("procirq 28");

        [EmptyMethod]
        private static void IRQ29() => asm("procirq 29");

        [EmptyMethod]
        private static void IRQ30() => asm("procirq 30");

        [EmptyMethod]
        private static void IRQ31() => asm("procirq 31");

        [EmptyMethod]
        private static void IRQ32() => asm("procirq 32");

        [EmptyMethod]
        private static void IRQ33() => asm("procirq 33");

        [EmptyMethod]
        private static void IRQ34() => asm("procirq 34");

        [EmptyMethod]
        private static void IRQ35() => asm("procirq 35");

        [EmptyMethod]
        private static void IRQ36() => asm("procirq 36");

        [EmptyMethod]
        private static void IRQ37() => asm("procirq 37");

        [EmptyMethod]
        private static void IRQ38() => asm("procirq 38");

        [EmptyMethod]
        private static void IRQ39() => asm("procirq 39");

        [EmptyMethod]
        private static void IRQ40() => asm("procirq 40");

        [EmptyMethod]
        private static void IRQ41() => asm("procirq 41");

        [EmptyMethod]
        private static void IRQ42() => asm("procirq 42");

        [EmptyMethod]
        private static void IRQ43() => asm("procirq 43");

        [EmptyMethod]
        private static void IRQ44() => asm("procirq 44");

        [EmptyMethod]
        private static void IRQ45() => asm("procirq 45");

        [EmptyMethod]
        private static void IRQ46() => asm("procirq 46");

        [EmptyMethod]
        private static void IRQ47() => asm("procirq 47");

        [EmptyMethod]
        private static void IRQ48() => asm("procirq 48");

        [EmptyMethod]
        private static void IRQ49() => asm("procirq 49");

        [EmptyMethod]
        private static void IRQ50() => asm("procirq 50");

        [EmptyMethod]
        private static void IRQ51() => asm("procirq 51");

        [EmptyMethod]
        private static void IRQ52() => asm("procirq 52");

        [EmptyMethod]
        private static void IRQ53() => asm("procirq 53");

        [EmptyMethod]
        private static void IRQ54() => asm("procirq 54");

        [EmptyMethod]
        private static void IRQ55() => asm("procirq 55");

        [EmptyMethod]
        private static void IRQ56() => asm("procirq 56");

        [EmptyMethod]
        private static void IRQ57() => asm("procirq 57");

        [EmptyMethod]
        private static void IRQ58() => asm("procirq 58");

        [EmptyMethod]
        private static void IRQ59() => asm("procirq 59");

        [EmptyMethod]
        private static void IRQ60() => asm("procirq 60");

        [EmptyMethod]
        private static void IRQ61() => asm("procirq 61");

        [EmptyMethod]
        private static void IRQ62() => asm("procirq 62");

        [EmptyMethod]
        private static void IRQ63() => asm("procirq 63");

        [EmptyMethod]
        private static void IRQ64() => asm("procirq 64");

        [EmptyMethod]
        private static void IRQ65() => asm("procirq 65");

        [EmptyMethod]
        private static void IRQ66() => asm("procirq 66");

        [EmptyMethod]
        private static void IRQ67() => asm("procirq 67");

        [EmptyMethod]
        private static void IRQ68() => asm("procirq 68");

        [EmptyMethod]
        private static void IRQ69() => asm("procirq 69");

        [EmptyMethod]
        private static void IRQ70() => asm("procirq 70");

        [EmptyMethod]
        private static void IRQ71() => asm("procirq 71");

        [EmptyMethod]
        private static void IRQ72() => asm("procirq 72");

        [EmptyMethod]
        private static void IRQ73() => asm("procirq 73");

        [EmptyMethod]
        private static void IRQ74() => asm("procirq 74");

        [EmptyMethod]
        private static void IRQ75() => asm("procirq 75");

        [EmptyMethod]
        private static void IRQ76() => asm("procirq 76");

        [EmptyMethod]
        private static void IRQ77() => asm("procirq 77");

        [EmptyMethod]
        private static void IRQ78() => asm("procirq 78");

        [EmptyMethod]
        private static void IRQ79() => asm("procirq 79");

        [EmptyMethod]
        private static void IRQ80() => asm("procirq 80");

        [EmptyMethod]
        private static void IRQ81() => asm("procirq 81");

        [EmptyMethod]
        private static void IRQ82() => asm("procirq 82");

        [EmptyMethod]
        private static void IRQ83() => asm("procirq 83");

        [EmptyMethod]
        private static void IRQ84() => asm("procirq 84");

        [EmptyMethod]
        private static void IRQ85() => asm("procirq 85");

        [EmptyMethod]
        private static void IRQ86() => asm("procirq 86");

        [EmptyMethod]
        private static void IRQ87() => asm("procirq 87");

        [EmptyMethod]
        private static void IRQ88() => asm("procirq 88");

        [EmptyMethod]
        private static void IRQ89() => asm("procirq 89");

        [EmptyMethod]
        private static void IRQ90() => asm("procirq 90");

        [EmptyMethod]
        private static void IRQ91() => asm("procirq 91");

        [EmptyMethod]
        private static void IRQ92() => asm("procirq 92");

        [EmptyMethod]
        private static void IRQ93() => asm("procirq 93");

        [EmptyMethod]
        private static void IRQ94() => asm("procirq 94");

        [EmptyMethod]
        private static void IRQ95() => asm("procirq 95");

        [EmptyMethod]
        private static void IRQ96() => asm("procirq 96");

        [EmptyMethod]
        private static void IRQ97() => asm("procirq 97");

        [EmptyMethod]
        private static void IRQ98() => asm("procirq 98");

        [EmptyMethod]
        private static void IRQ99() => asm("procirq 99");

        [EmptyMethod]
        private static void IRQ100() => asm("procirq 100");

        [EmptyMethod]
        private static void IRQ101() => asm("procirq 101");

        [EmptyMethod]
        private static void IRQ102() => asm("procirq 102");

        [EmptyMethod]
        private static void IRQ103() => asm("procirq 103");

        [EmptyMethod]
        private static void IRQ104() => asm("procirq 104");

        [EmptyMethod]
        private static void IRQ105() => asm("procirq 105");

        [EmptyMethod]
        private static void IRQ106() => asm("procirq 106");

        [EmptyMethod]
        private static void IRQ107() => asm("procirq 107");

        [EmptyMethod]
        private static void IRQ108() => asm("procirq 108");

        [EmptyMethod]
        private static void IRQ109() => asm("procirq 109");

        [EmptyMethod]
        private static void IRQ110() => asm("procirq 110");

        [EmptyMethod]
        private static void IRQ111() => asm("procirq 111");

        [EmptyMethod]
        private static void IRQ112() => asm("procirq 112");

        [EmptyMethod]
        private static void IRQ113() => asm("procirq 113");

        [EmptyMethod]
        private static void IRQ114() => asm("procirq 114");

        [EmptyMethod]
        private static void IRQ115() => asm("procirq 115");

        [EmptyMethod]
        private static void IRQ116() => asm("procirq 116");

        [EmptyMethod]
        private static void IRQ117() => asm("procirq 117");

        [EmptyMethod]
        private static void IRQ118() => asm("procirq 118");

        [EmptyMethod]
        private static void IRQ119() => asm("procirq 119");

        [EmptyMethod]
        private static void IRQ120() => asm("procirq 120");

        [EmptyMethod]
        private static void IRQ121() => asm("procirq 121");

        [EmptyMethod]
        private static void IRQ122() => asm("procirq 122");

        [EmptyMethod]
        private static void IRQ123() => asm("procirq 123");

        [EmptyMethod]
        private static void IRQ124() => asm("procirq 124");

        [EmptyMethod]
        private static void IRQ125() => asm("procirq 125");

        [EmptyMethod]
        private static void IRQ126() => asm("procirq 126");

        [EmptyMethod]
        private static void IRQ127() => asm("procirq 127");

        [EmptyMethod]
        private static void IRQ128() => asm("procirq 128");

        [EmptyMethod]
        private static void IRQ129() => asm("procirq 129");

        [EmptyMethod]
        private static void IRQ130() => asm("procirq 130");

        [EmptyMethod]
        private static void IRQ131() => asm("procirq 131");

        [EmptyMethod]
        private static void IRQ132() => asm("procirq 132");

        [EmptyMethod]
        private static void IRQ133() => asm("procirq 133");

        [EmptyMethod]
        private static void IRQ134() => asm("procirq 134");

        [EmptyMethod]
        private static void IRQ135() => asm("procirq 135");

        [EmptyMethod]
        private static void IRQ136() => asm("procirq 136");

        [EmptyMethod]
        private static void IRQ137() => asm("procirq 137");

        [EmptyMethod]
        private static void IRQ138() => asm("procirq 138");

        [EmptyMethod]
        private static void IRQ139() => asm("procirq 139");

        [EmptyMethod]
        private static void IRQ140() => asm("procirq 140");

        [EmptyMethod]
        private static void IRQ141() => asm("procirq 141");

        [EmptyMethod]
        private static void IRQ142() => asm("procirq 142");

        [EmptyMethod]
        private static void IRQ143() => asm("procirq 143");

        [EmptyMethod]
        private static void IRQ144() => asm("procirq 144");

        [EmptyMethod]
        private static void IRQ145() => asm("procirq 145");

        [EmptyMethod]
        private static void IRQ146() => asm("procirq 146");

        [EmptyMethod]
        private static void IRQ147() => asm("procirq 147");

        [EmptyMethod]
        private static void IRQ148() => asm("procirq 148");

        [EmptyMethod]
        private static void IRQ149() => asm("procirq 149");

        [EmptyMethod]
        private static void IRQ150() => asm("procirq 150");

        [EmptyMethod]
        private static void IRQ151() => asm("procirq 151");

        [EmptyMethod]
        private static void IRQ152() => asm("procirq 152");

        [EmptyMethod]
        private static void IRQ153() => asm("procirq 153");

        [EmptyMethod]
        private static void IRQ154() => asm("procirq 154");

        [EmptyMethod]
        private static void IRQ155() => asm("procirq 155");

        [EmptyMethod]
        private static void IRQ156() => asm("procirq 156");

        [EmptyMethod]
        private static void IRQ157() => asm("procirq 157");

        [EmptyMethod]
        private static void IRQ158() => asm("procirq 158");

        [EmptyMethod]
        private static void IRQ159() => asm("procirq 159");

        [EmptyMethod]
        private static void IRQ160() => asm("procirq 160");

        [EmptyMethod]
        private static void IRQ161() => asm("procirq 161");

        [EmptyMethod]
        private static void IRQ162() => asm("procirq 162");

        [EmptyMethod]
        private static void IRQ163() => asm("procirq 163");

        [EmptyMethod]
        private static void IRQ164() => asm("procirq 164");

        [EmptyMethod]
        private static void IRQ165() => asm("procirq 165");

        [EmptyMethod]
        private static void IRQ166() => asm("procirq 166");

        [EmptyMethod]
        private static void IRQ167() => asm("procirq 167");

        [EmptyMethod]
        private static void IRQ168() => asm("procirq 168");

        [EmptyMethod]
        private static void IRQ169() => asm("procirq 169");

        [EmptyMethod]
        private static void IRQ170() => asm("procirq 170");

        [EmptyMethod]
        private static void IRQ171() => asm("procirq 171");

        [EmptyMethod]
        private static void IRQ172() => asm("procirq 172");

        [EmptyMethod]
        private static void IRQ173() => asm("procirq 173");

        [EmptyMethod]
        private static void IRQ174() => asm("procirq 174");

        [EmptyMethod]
        private static void IRQ175() => asm("procirq 175");

        [EmptyMethod]
        private static void IRQ176() => asm("procirq 176");

        [EmptyMethod]
        private static void IRQ177() => asm("procirq 177");

        [EmptyMethod]
        private static void IRQ178() => asm("procirq 178");

        [EmptyMethod]
        private static void IRQ179() => asm("procirq 179");

        [EmptyMethod]
        private static void IRQ180() => asm("procirq 180");

        [EmptyMethod]
        private static void IRQ181() => asm("procirq 181");

        [EmptyMethod]
        private static void IRQ182() => asm("procirq 182");

        [EmptyMethod]
        private static void IRQ183() => asm("procirq 183");

        [EmptyMethod]
        private static void IRQ184() => asm("procirq 184");

        [EmptyMethod]
        private static void IRQ185() => asm("procirq 185");

        [EmptyMethod]
        private static void IRQ186() => asm("procirq 186");

        [EmptyMethod]
        private static void IRQ187() => asm("procirq 187");

        [EmptyMethod]
        private static void IRQ188() => asm("procirq 188");

        [EmptyMethod]
        private static void IRQ189() => asm("procirq 189");

        [EmptyMethod]
        private static void IRQ190() => asm("procirq 190");

        [EmptyMethod]
        private static void IRQ191() => asm("procirq 191");

        [EmptyMethod]
        private static void IRQ192() => asm("procirq 192");

        [EmptyMethod]
        private static void IRQ193() => asm("procirq 193");

        [EmptyMethod]
        private static void IRQ194() => asm("procirq 194");

        [EmptyMethod]
        private static void IRQ195() => asm("procirq 195");

        [EmptyMethod]
        private static void IRQ196() => asm("procirq 196");

        [EmptyMethod]
        private static void IRQ197() => asm("procirq 197");

        [EmptyMethod]
        private static void IRQ198() => asm("procirq 198");

        [EmptyMethod]
        private static void IRQ199() => asm("procirq 199");

        [EmptyMethod]
        private static void IRQ200() => asm("procirq 200");

        [EmptyMethod]
        private static void IRQ201() => asm("procirq 201");

        [EmptyMethod]
        private static void IRQ202() => asm("procirq 202");

        [EmptyMethod]
        private static void IRQ203() => asm("procirq 203");

        [EmptyMethod]
        private static void IRQ204() => asm("procirq 204");

        [EmptyMethod]
        private static void IRQ205() => asm("procirq 205");

        [EmptyMethod]
        private static void IRQ206() => asm("procirq 206");

        [EmptyMethod]
        private static void IRQ207() => asm("procirq 207");

        [EmptyMethod]
        private static void IRQ208() => asm("procirq 208");

        [EmptyMethod]
        private static void IRQ209() => asm("procirq 209");

        [EmptyMethod]
        private static void IRQ210() => asm("procirq 210");

        [EmptyMethod]
        private static void IRQ211() => asm("procirq 211");

        [EmptyMethod]
        private static void IRQ212() => asm("procirq 212");

        [EmptyMethod]
        private static void IRQ213() => asm("procirq 213");

        [EmptyMethod]
        private static void IRQ214() => asm("procirq 214");

        [EmptyMethod]
        private static void IRQ215() => asm("procirq 215");

        [EmptyMethod]
        private static void IRQ216() => asm("procirq 216");

        [EmptyMethod]
        private static void IRQ217() => asm("procirq 217");

        [EmptyMethod]
        private static void IRQ218() => asm("procirq 218");

        [EmptyMethod]
        private static void IRQ219() => asm("procirq 219");

        [EmptyMethod]
        private static void IRQ220() => asm("procirq 220");

        [EmptyMethod]
        private static void IRQ221() => asm("procirq 221");

        [EmptyMethod]
        private static void IRQ222() => asm("procirq 222");

        [EmptyMethod]
        private static void IRQ223() => asm("procirq 223");

        [EmptyMethod]
        private static void IRQ224() => asm("procirq 224");

        [EmptyMethod]
        private static void IRQ225() => asm("procirq 225");

        [EmptyMethod]
        private static void IRQ226() => asm("procirq 226");

        [EmptyMethod]
        private static void IRQ227() => asm("procirq 227");

        [EmptyMethod]
        private static void IRQ228() => asm("procirq 228");

        [EmptyMethod]
        private static void IRQ229() => asm("procirq 229");

        [EmptyMethod]
        private static void IRQ230() => asm("procirq 230");

        [EmptyMethod]
        private static void IRQ231() => asm("procirq 231");

        [EmptyMethod]
        private static void IRQ232() => asm("procirq 232");

        [EmptyMethod]
        private static void IRQ233() => asm("procirq 233");

        [EmptyMethod]
        private static void IRQ234() => asm("procirq 234");

        [EmptyMethod]
        private static void IRQ235() => asm("procirq 235");

        [EmptyMethod]
        private static void IRQ236() => asm("procirq 236");

        [EmptyMethod]
        private static void IRQ237() => asm("procirq 237");

        [EmptyMethod]
        private static void IRQ238() => asm("procirq 238");

        [EmptyMethod]
        private static void IRQ239() => asm("procirq 239");

        [EmptyMethod]
        private static void IRQ240() => asm("procirq 240");

        [EmptyMethod]
        private static void IRQ241() => asm("procirq 241");

        [EmptyMethod]
        private static void IRQ242() => asm("procirq 242");

        [EmptyMethod]
        private static void IRQ243() => asm("procirq 243");

        [EmptyMethod]
        private static void IRQ244() => asm("procirq 244");

        [EmptyMethod]
        private static void IRQ245() => asm("procirq 245");

        [EmptyMethod]
        private static void IRQ246() => asm("procirq 246");

        [EmptyMethod]
        private static void IRQ247() => asm("procirq 247");

        [EmptyMethod]
        private static void IRQ248() => asm("procirq 248");

        [EmptyMethod]
        private static void IRQ249() => asm("procirq 249");

        [EmptyMethod]
        private static void IRQ250() => asm("procirq 250");

        [EmptyMethod]
        private static void IRQ251() => asm("procirq 251");

        [EmptyMethod]
        private static void IRQ252() => asm("procirq 252");

        [EmptyMethod]
        private static void IRQ253() => asm("procirq 253");

        [EmptyMethod]
        private static void IRQ254() => asm("procirq 254");

        [EmptyMethod]
        private static void IRQ255() => asm("procirq 255");
    }
}
