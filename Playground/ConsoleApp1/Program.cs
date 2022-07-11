using System.Platform.Amd64;
using System.Runtime.CompilerServices;

namespace ConsoleApp1
{
    public static unsafe class Program
    {
        public static void Main() {}

        [CompilerMethod(Methods.EntryPoint)]
        public static void Main(MultibootInfo* info, ulong magic)
        {
            Serial.WriteLine("Hello from ConsoleApp1!");
            const ulong add = 4 + 8;
            Serial.WriteLine(add.ToString());
            BGA.Setup();
            BGA.SetVideoMode(640, 480);
            PS2Mouse.X = BGA.Width / 2;
            PS2Mouse.Y = BGA.Height / 2;

            var cursor = new[]
            {
                1,0,0,0,0,0,0,0,0,0,0,0,
                1,1,0,0,0,0,0,0,0,0,0,0,
                1,2,1,0,0,0,0,0,0,0,0,0,
                1,2,2,1,0,0,0,0,0,0,0,0,
                1,2,2,2,1,0,0,0,0,0,0,0,
                1,2,2,2,2,1,0,0,0,0,0,0,
                1,2,2,2,2,2,1,0,0,0,0,0,
                1,2,2,2,2,2,2,1,0,0,0,0,
                1,2,2,2,2,2,2,2,1,0,0,0,
                1,2,2,2,2,2,2,2,2,1,0,0,
                1,2,2,2,2,2,2,2,2,2,1,0,
                1,2,2,2,2,2,2,2,2,2,2,1,
                1,2,2,2,2,2,2,1,1,1,1,1,
                1,2,2,2,1,2,2,1,0,0,0,0,
                1,2,2,1,0,1,2,2,1,0,0,0,
                1,2,1,0,0,1,2,2,1,0,0,0,
                1,1,0,0,0,0,1,2,2,1,0,0,
                0,0,0,0,0,0,1,2,2,1,0,0,
                0,0,0,0,0,0,0,1,2,2,1,0,
                0,0,0,0,0,0,0,1,2,2,1,0,
                0,0,0,0,0,0,0,0,1,1,0,0
            };

            for (;;)
            {
                BGA.Clear(0);
                ASC16.DrawString("FPS:", 10, 10, 0xFFFFFFFF);
                ASC16.DrawString(((ulong)FPSMeter.FPS).ToString(), 42, 10, 0xFFFFFFFF);
                DrawCursor(cursor, PS2Mouse.X, PS2Mouse.Y);
                BGA.Update();
                FPSMeter.Update();
            }
        }

        private static void DrawCursor(int[] cursor, int x, int y)
        {
            for (var h = 0; h < 21; h++)
                for (var w = 0; w < 12; w++)
                {
                    if (cursor[h * 12 + w] == 1)
                        BGA.DrawPoint(w + x, h + y, 0xFFFFFFFF);

                    if (cursor[h * 12 + w] == 2)
                        BGA.DrawPoint(w + x, h + y, 0x0);
                }
        }
    }
}
