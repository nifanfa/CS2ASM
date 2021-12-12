using System.Platform.Amd64;

namespace ConsoleApp1
{
    public static unsafe class Program
    {
        public static void Main()
        {
            Console.Write("Hello World! CS2ASM By nifanfa And Contributors: LeonTheDev");
            Console.BackgroundColor = ConsoleColor.Purple;
            Console.ForegroundColor = ConsoleColor.White;
            for (byte y = 10; y < 15; y++)
                for (byte x = 35; x < 45; x++)
                {
                    Console.WriteAt(' ', x, y);
                    if (x == 38 && y == 12)
                        Console.WriteAt('.', x, y);
                    if (x == 39 && y == 12)
                        Console.WriteAt('N', x, y);
                    if (x == 40 && y == 12)
                        Console.WriteAt('E', x, y);
                    if (x == 41 && y == 12)
                        Console.WriteAt('T', x, y);
                }
            Console.ResetColor();
            //Shutdown after 2sec
            //PIT.Wait(2000);
            //x64.Out16(0x604, 0x2000);
            for (; ; );
        }
    }
}
