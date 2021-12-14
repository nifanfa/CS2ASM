using System;
using System.Platform.Amd64;

namespace ConsoleApp1
{
    public static unsafe class Program
    {
        public static void Main()
        {
            x64.Out8(0x60, 0x00);
            Banner();

            ulong[] array = new ulong[2];
            array[0] = 123456789;
            array[1] = 54321;

            Console.WriteLine("Welcome to the CS2ASM demo!");
            Console.WriteLine("Owner: nifanfa");
            Console.WriteLine("Contributors: LeonTheDev");

            Console.WriteLine(Convert.ToString(array[0]));
            Console.WriteLine(Convert.ToString(array[1]));

            for (; ; );
        }

        public static void Banner()
        {
            Console.BackgroundColor = ConsoleColor.Purple;
            Console.ForegroundColor = ConsoleColor.White;
            for (byte y = 9; y < 16; y++)
            {
                for (byte x = 34; x < 46; x++)
                {
                    Console.WriteAt(' ', x, y);
                }
            }
            Console.WriteAt('.', 38, 12);
            Console.WriteAt('N', 39, 12);
            Console.WriteAt('E', 40, 12);
            Console.WriteAt('T', 41, 12);
            Console.ResetColor();
        }
    }
}
