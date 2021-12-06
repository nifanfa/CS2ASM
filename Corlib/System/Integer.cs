
namespace System
{
    public static class Integer
    {
        public static int GetFirstDigit(int i)
        {
            int firstDigit = i;
            while (firstDigit >= 10)
            {
                firstDigit = firstDigit / 10;
            }
            return firstDigit;
        }
        
        public static int GetLength(int x)
        {
            if (x >= 1000000000) return 10;
            if (x >= 100000000) return 9;
            if (x >= 10000000) return 8;
            if (x >= 1000000) return 7;
            if (x >= 100000) return 6;
            if (x >= 10000) return 5;
            if (x >= 1000) return 4;
            if (x >= 100) return 3;
            if (x >= 10) return 2;
            return 1;
        }

        public static int GetLastDigit(int i)
        {
            int lastDigit = i;
            lastDigit = i - (i / 10) * 10;
            return lastDigit;
        }
    }
}
