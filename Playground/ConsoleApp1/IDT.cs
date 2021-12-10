namespace ConsoleApp1
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
            IDTEntry* Entries = (IDTEntry*)0x320_0000;
            Set(Entries, 0, (uint)(delegate* <void>)(&ISR0), 0x08, 0x8E);
            Set(Entries, 1, (uint)(delegate* <void>)(&ISR1), 0x08, 0x8E);

            IDTDescriptor* Descriptor = (IDTDescriptor*)0x321_0000;
            Descriptor->Limit = (ushort)((sizeof(IDTEntry) * 2) - 1);
            Descriptor->Base = (ulong)Entries;
        }

        private static void ISR0() 
        {
        }

        private static void ISR1()
        {
        }

        private static void Set(IDTEntry* Entry,int Index,uint Base,ushort Selector,byte TypeAttribute) 
        {
            (&Entry[Index])->BaseLow = (ushort)(Base & 0xFFFF);
            (&Entry[Index])->BaseMid = (ushort)((Base >> 16) & 0xFFFF);
            (&Entry[Index])->BaseHigh = ((Base >> 32) & 0xFFFFFFFF);
            (&Entry[Index])->Selector = Selector;
            (&Entry[Index])->TypeAttributes = TypeAttribute;
            (&Entry[Index])->Reserved0 = 0;
            (&Entry[Index])->Reserved1 = 0;
        }
    }
}
