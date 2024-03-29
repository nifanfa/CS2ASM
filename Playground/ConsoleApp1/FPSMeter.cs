using System.Platform.Amd64;

namespace ConsoleApp1
{
    internal static class FPSMeter
    {
        public static int FPS = 0;

        public static int LastS = -1;
        public static int Ticken = 0;

        public static void Update()
        {
            if (LastS == -1)
            {
                LastS = RTC.Second;
            }
            if (RTC.Second - LastS != 0)
            {
                if (RTC.Second > LastS)
                {
                    FPS = Ticken / (RTC.Second - LastS);
                }
                LastS = RTC.Second;
                Ticken = 0;
            }
            Ticken++;
        }
    }
}

