using static System.Runtime.Intrinsic;

namespace System.Platform.Amd64
{
    public static unsafe class Paging
    {
        public static ulong* pml4 = (ulong*)0x3FE000;

        static Paging()
        {
            x64.Stosb(pml4, 0x00, 4096);

            //Map the first 1GiB
            for (ulong i = 0; i < 1024UL * 1024UL * 1024UL * 1UL; i += 0x200000)
            {
                Map(i, i);
            }

            void* p = pml4;
            asm("xor rax,rax");
            asm("mov eax,{p}");
            asm("mov cr3,rax");
        }

        /// <summary>
        /// Map 2MiB Physical Address At Virtual Address Specificed
        /// </summary>
        /// <param name="Virt"></param>
        /// <param name="Phys"></param>
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
                p = AllocateTable();
                Curr[Entry] = (((ulong)p) & 0x000F_FFFF_FFFF_F000) | 0b11;
            }

            return p;
        }

        private static ulong p = 0;

        public static ulong* AllocateTable() 
        {
            ulong* r = (ulong*)(0x400000 + (p * 4096));
            x64.Stosb(r, 0x00, 4096);
            p++;
            return r;
        }
    }
}
