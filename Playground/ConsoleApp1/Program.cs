using System;
using System.Runtime;
using Toolkit;
using static System.Runtime.Intrinsic;

namespace ConsoleApp1
{
    public static unsafe class Program
    {
        /*
         * Current Progress:
         *  Currently, only static methods are supported.
         *  Currently, only local and static variables are supported.
         *  Pointers are supported.
         *  Void, Boolean, Char, SByte, Byte, Short, UShort, Int, UInt, Long and ULong are all supported.
         *  Arithmetic operations such as +, -, *, /, << and >> are all supported.
         *  Logic operations such as >, >=, <, <= and == are all supported.
         *  Other instructions such as loops, if statements and returning variables are all supported.
         *
         *  TODO - Free the unused strings
         *  TODO - Inherited class implementation
         */

        public struct StructTest 
        {
            public byte U1;
            public byte U2;
        }

        public static void Main()
        {
            //shutdown qemu
            //IOPort.Out16(0x604, 0x2000);

            //In8(0x60);

            Console.Setup();

            Console.Clear();
            Console.Alphabet();

            string s0 = "Hello World from CS2ASM. You are in x64 mode!";

            Console.WriteStr(s0, 1);

            string s1 = "Contributors: nifanfa (Owner), LeonTheDev";

            Console.WriteStr(s1, 2);

            //Call the methods in StaticLib
            asm("call Hello");

            StructTest* STP = (StructTest*)0xb8360;
            STP->U1 = 0x11;
            STP->U2 = 0x99;

            byte* p = (byte*)0xb865e;
            ulong u1 = 3;
            ulong u2 = 2;
            //*p = (byte)(u1 / u2);

            // IDT On Interrupt not implemented yet, using loop for now.
            Console.ForegroundColor = ConsoleColor.LightCyan;
            for (; ; )
            {
                char c = PS2Keyboard.GetKeyPressed();
                Console.WriteAt(c, 0, 24);
                if (c == 'G')
                {
                    IOPort.Out8(0x64, 0xFE); // CPU Reboot
                }
            }
            //Counter();
        }

        public static void EmptyMethod() 
        {
        }

        // Counts to 9 and resets
        public static void Counter()
        {
            byte b = 0x30; // 0
        Loop:
            for (int i = 0; i < 10; i++)
            {
                Console.WriteAt((char)b, 0, 24);
                b++;
            }
            b = 0x30; // 0
            goto Loop;
        }
    }
}
