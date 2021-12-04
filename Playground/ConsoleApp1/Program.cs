using Toolkit;

namespace ConsoleApp1
{
    public class aClass 
    {
        public ulong u = 0x1122334455667788;
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
         *  Allocation is not supported yet!
         */
        public static void Main()
        {
            Console.Setup();

            Console.Clear();
            Console.Alphabet();

            ulong* p = (ulong*)0xb8050;
            *p = 0x0f410f420f430f44;

            aClass aClass = new aClass();

            *p = aClass.u;

            Counter();
        }

        public static ulong malloc() 
        {
            return 0x640_0000UL;
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
