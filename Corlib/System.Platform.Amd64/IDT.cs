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
            IDTEntry* Entries = (IDTEntry*)0x320_0000;

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

            IDTDescriptor* Descriptor = (IDTDescriptor*)0x321_0000;
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
        }


        [EmptyMethod]
        private static void IRQ0()
        {
        }

        [EmptyMethod]
        private static void IRQ1()
        {
        }

        [EmptyMethod]
        private static void IRQ2()
        {
        }

        [EmptyMethod]
        private static void IRQ3()
        {
        }

        [EmptyMethod]
        private static void IRQ4()
        {
        }

        [EmptyMethod]
        private static void IRQ5()
        {
        }

        [EmptyMethod]
        private static void IRQ6()
        {
        }

        [EmptyMethod]
        private static void IRQ7()
        {
        }

        [EmptyMethod]
        private static void IRQ8()
        {
        }

        [EmptyMethod]
        private static void IRQ9()
        {
        }

        [EmptyMethod]
        private static void IRQ10()
        {
        }

        [EmptyMethod]
        private static void IRQ11()
        {
        }

        [EmptyMethod]
        private static void IRQ12()
        {
        }

        [EmptyMethod]
        private static void IRQ13()
        {
        }

        [EmptyMethod]
        private static void IRQ14()
        {
        }

        [EmptyMethod]
        private static void IRQ15()
        {
        }

        [EmptyMethod]
        private static void IRQ16()
        {
        }

        [EmptyMethod]
        private static void IRQ17()
        {
        }

        [EmptyMethod]
        private static void IRQ18()
        {
        }

        [EmptyMethod]
        private static void IRQ19()
        {
        }

        [EmptyMethod]
        private static void IRQ20()
        {
        }

        [EmptyMethod]
        private static void IRQ21()
        {
        }

        [EmptyMethod]
        private static void IRQ22()
        {
        }

        [EmptyMethod]
        private static void IRQ23()
        {
        }

        [EmptyMethod]
        private static void IRQ24()
        {
        }

        [EmptyMethod]
        private static void IRQ25()
        {
        }

        [EmptyMethod]
        private static void IRQ26()
        {
        }

        [EmptyMethod]
        private static void IRQ27()
        {
        }

        [EmptyMethod]
        private static void IRQ28()
        {
        }

        [EmptyMethod]
        private static void IRQ29()
        {
        }

        [EmptyMethod]
        private static void IRQ30()
        {
        }

        [EmptyMethod]
        private static void IRQ31()
        {
        }

        [EmptyMethod]
        private static void IRQ32()
        {
        }

        [EmptyMethod]
        private static void IRQ33()
        {
            asm("pushaq");
            asm("push 33"); //This will be cleared automatically after call System.Platform.Amd64.IDT.OnInterrupt
            asm("call System.Platform.Amd64.IDT.OnInterrupt");
            asm("popaq");
            asm("iretq");
        }
    }
}
