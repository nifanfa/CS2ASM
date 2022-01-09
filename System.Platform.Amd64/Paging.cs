using static System.Runtime.Intrinsic;

namespace System.Platform.Amd64
{
    public static unsafe class Paging
    {
        public static ulong* pml4 = (ulong*)0x3FE000;

        static Paging()
        {
            for (ulong i = 0; i < 0x100000000; i += 0x200000)
            {
                Map(i, i);
            }

            void* p = pml4;
            asm("xor rax,rax");
            asm("mov eax,{p}");
            asm("mov cr3,rax");
            asm("mov rax,cr0");
            asm("or rax,0x80000001");
            asm("mov cr0,rax");
        }

        public static void Map(ulong Virt,ulong Phys) 
        {
            ulong pml4_entry = (Virt & ((ulong)0x1ff << 39)) >> 39;
            ulong pml3_entry = (Virt & ((ulong)0x1ff << 30)) >> 30;
            ulong pml2_entry = (Virt & ((ulong)0x1ff << 21)) >> 21;
            ulong pml1_entry = (Virt & ((ulong)0x1ff << 12)) >> 12;

            ulong* pml3 = Next(pml4, pml4_entry);
            ulong* pml2 = Next(pml3, pml3_entry);

            pml2[pml2_entry] = Phys | 0b10000011;
        }

        public static ulong* Next(ulong* Curr,ulong Entry) 
        {
            ulong* p = null;
            
            if(((Curr[Entry]) & 0x01) != 0) 
            {
                p = (ulong*)(Curr[Entry] & 0x000F_FFFF_FFFF_F000);
            }
            else 
            {
                p = Alloc();
                Curr[Entry] = (((ulong)p) & 0x000F_FFFF_FFFF_F000) | 0b11;
            }

            return p;
        }

        public static ulong P = 0;

        public static ulong* Alloc() 
        {
            ulong r = 0x400000 + (P * 4096);
            P++;
            return (ulong*)r;
        }
    }
}
