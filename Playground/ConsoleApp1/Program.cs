using Toolkit;

namespace ConsoleApp1
{
    public static unsafe class Program
    {
        /*
         * Current Progress:
         *  Only static methods supported.
         *  Only local and static variables supported.
         *  Pointers supported.
         *  SByte, Byte, Short, UShort, Int, UInt, Long, ULong, are all supported.
         *  C# basic things (for, if, etc, return, and more) supported.
         *
         *  Allocation is not yet supported!
         */
        public static void Main()
        {
            Console.Setup();

            Console.Clear();
            Console.Alphabet();

            Counter();
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
