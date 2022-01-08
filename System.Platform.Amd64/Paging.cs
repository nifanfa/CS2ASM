using static System.Runtime.Intrinsic;

namespace System.Platform.Amd64
{
    public static unsafe class Paging
    {
        static Paging()
        {
            //Map 512GiB In PageTable
            ulong* p4 = (ulong*)0x3FE000;
            ulong* p3 = (ulong*)0x3FF000;
            ulong* p2 = (ulong*)0x400000;

            p4[0] = (((ulong)p3)) | 0b11;

            for (ulong i = 0; i < 512; i++)
            {
                p3[i] = ((ulong)p2 + (i * 4096)) | 0b11;
            }

            for (ulong i = 0; i < 512 * 512; i++)
            {
                p2[i] = (((i * 0x200000) >> 12) << 12) | 0b10000011;
            }

            asm("xor rax,rax");
            asm("mov eax,{p4}");
            asm("mov cr3,rax");
        }
    }
}
