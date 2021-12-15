using static System.Runtime.Intrinsic;

namespace System.Platform.Amd64
{
    public static unsafe class Paging
    {
        static Paging() 
        {
            //Map 512GiB
            //Bug!
            /*
            ulong* P4 = (ulong*)0x800000;
            ulong* P3 = (ulong*)0x810000;
            ulong* P2Start = (ulong*)0x820000;
            P4[0] = (ulong)P3 | 0b11;

            //512*512
            for(ulong i = 0; i < 0x40000; i++) 
            {
                P2Start[i] = (i * 0x200000) | 0b10000011;
            }

            for(ulong i = 0; i < 512; i++) 
            {
                P3[i] = (ulong)P2Start + (4096 * i) | 0b11;
            }

            asm("mov rax,{P4}");
            asm("mov cr3,rax");
            */
        }
    }
}
