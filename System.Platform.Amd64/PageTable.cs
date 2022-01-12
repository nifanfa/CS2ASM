using static System.Runtime.Intrinsic;

namespace System.Platform.Amd64
{
    public static unsafe class PageTable
    {
        public const ulong PageSize = 0x200000;

        public static ulong* PML4 = (ulong*)0x3FE000;

        static PageTable()
        {
            x64.Stosb(PML4, 0x00, 4096);

            //Map the first 1GiB
            for (ulong i = 0; i < 1024UL * 1024UL * 1024UL * 1UL; i += PageSize)
            {
                Map(i, i);
            }

            void* p = PML4;
            asm("xor rax,rax");
            asm("mov eax,{p}");
            asm("mov cr3,rax");
        }

        /// <summary>
        /// Map 2MiB Physical Address At Virtual Address Specificed
        /// </summary>
        /// <param name="VirtualAddress"></param>
        /// <param name="PhysicalAddress"></param>
        public static void Map(ulong VirtualAddress, ulong PhysicalAddress, ulong Attribute = 0) 
        {
            ulong pml4_entry = (VirtualAddress & ((ulong)0x1ff << 39)) >> 39;
            ulong pml3_entry = (VirtualAddress & ((ulong)0x1ff << 30)) >> 30;
            ulong pml2_entry = (VirtualAddress & ((ulong)0x1ff << 21)) >> 21;
            ulong pml1_entry = (VirtualAddress & ((ulong)0x1ff << 12)) >> 12;

            ulong* pml3 = Next(PML4, pml4_entry);
            ulong* pml2 = Next(pml3, pml3_entry);

            pml2[pml2_entry] = PhysicalAddress | 0b10000011 | Attribute;

            x64.Invlpg(PhysicalAddress);
        }

        public static ulong* Next(ulong* Directory,ulong Entry) 
        {
            ulong* p = null;
            
            if(((Directory[Entry]) & 0x01) != 0) 
            {
                p = (ulong*)(Directory[Entry] & 0x000F_FFFF_FFFF_F000);
            }
            else 
            {
                p = AllocateTable();
                Directory[Entry] = (((ulong)p) & 0x000F_FFFF_FFFF_F000) | 0b11;
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
