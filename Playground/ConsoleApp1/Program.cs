using System.Platform.Amd64;

namespace ConsoleApp1
{
    public static unsafe class Program
    {
        public static void Main()
        {
            Console.Setup();
            Console.BackgroundColor = ConsoleColor.Purple;
            Console.ForegroundColor = ConsoleColor.White;
            for (byte y = 5; y < 20; y++)
                for (byte x = 25; x < 55; x++)
                {
                    Console.WriteAt(' ', x, y);
                    if (x == 38 && y == 13)
                        Console.WriteAt('.', x, y);
                    if (x == 39 && y == 13)
                        Console.WriteAt('N', x, y);
                    if (x == 40 && y == 13)
                        Console.WriteAt('E', x, y);
                    if (x == 41 && y == 13)
                        Console.WriteAt('T', x, y);
                }
        }
    }
}
