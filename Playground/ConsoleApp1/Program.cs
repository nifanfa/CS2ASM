using System.Platform.Amd64;

namespace ConsoleApp1
{
    public static unsafe class Program
    {
        public static void Main()
        {
            x64.Out8(0x60, 0x00);
            Banner();

            Console.ResetColor();
            Console.Write("Welcome to the CS2ASM demo!");
            Console.ForegroundColor = ConsoleColor.LightGreen;
            Console.WriteStrAt("Owner: nifanfa", 1);
            Console.WriteStrAt("Contributors: LeonTheDev", 2);
            Console.ResetColor();
            for (; ; );
        }

        public static void Banner()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            for (byte y = 9; y < 16; y++)
            {
                for (byte x = 34; x < 46; x++)
                {
                    Console.WriteAt(' ', x, y);
                }
            }
            Console.WriteAt('C', 37, 12);
            Console.WriteAt('S', 38, 12);
            Console.WriteAt('2', 39, 12);
            Console.WriteAt('A', 40, 12);
            Console.WriteAt('S', 41, 12);
            Console.WriteAt('M', 42, 12);
        }
    }
}
