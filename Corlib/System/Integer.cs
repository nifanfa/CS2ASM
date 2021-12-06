
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

        public static int GetLastDigit(int i)
        {
            int lastDigit = i;
            lastDigit = i - (i / 10) * 10;
            return lastDigit;
        }
    }
}
