﻿using System;
using System.Runtime;
using System.Platform.Amd64;
using static System.Runtime.Intrinsic;

namespace ConsoleApp1
{
    public class TestClass
    {
        public ulong Value = 123456;

        public void WriteValue(byte line) 
        {
            Console.WriteStr(Convert.ToString(Value), line);
        }

        public void WriteLine(string s,byte line) 
        {
            Console.WriteStr(s, line);
        }
    }

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
         *  Don't instance strings in a loop make it static
         */

        public struct StructTest 
        {
            public byte U1;
            public byte U2;
            public byte U3;
            public byte U4;
        }

        public static void Main()
        {
            TestClass testClass = new TestClass();
            TestClass testClass1 = new TestClass();
            //testClass.Size = 100;

            //shutdown qemu
            //x64.Out16(0x604, 0x2000);

            //In8(0x60);

            Console.Setup();

            Console.Clear();
            Console.Alphabet();

            string s0 = "Hello World from CS2ASM. You are in x64 mode!";

            Console.WriteStr(s0, 1);

            string s1 = "Contributors: nifanfa (Owner), LeonTheDev";

            Console.WriteStr(Convert.ToString(testClass.Size), 19);
            Console.WriteStr(Convert.ToString(testClass.Value), 20);
            Console.WriteStr(Convert.ToString(s1.Size), 21);

            testClass.WriteLine("Hello World", 10);

            testClass.Value = 123456;
            testClass1.Value = 654321;
            testClass.WriteValue(11);
            testClass1.WriteValue(12);

            Console.WriteStr(s1, 2);

            StructTest* STP = (StructTest*)0xb8360;
            (&STP[0])->U1 = 0x52;
            (&STP[0])->U2 = 0x20;
            (&STP[2])->U1 = 0x52;
            (&STP[2])->U2 = 0x20;

            //STP->U3 = (byte)(STP->U1 % STP->U2);
            //STP->U3 = (byte)(STP->U1 / STP->U2);

            Loop();
        }

        public static void EmptyMethod() 
        {
        }

        // Counts to 9 and resets. Also manages keyboard input.
        public static void Loop()
        {
            byte b = 0x30; // 0
        Loop:
            for (int i = 0; i < 10; i++)
            {
                byte tempColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteAt((char)b, 79, 24);
                b++;
                Console.ForegroundColor = tempColor;
            }
            b = 0x30; // 0
            goto Loop;
        }
    }
}
