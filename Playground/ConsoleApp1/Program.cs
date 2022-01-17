using System;
using System.Platform.Amd64;
using System.Runtime.CompilerServices;
using static System.Runtime.CompilerServices.Unsafe;

namespace ConsoleApp1
{
    public static unsafe class Program
    {
        public static void Main()
        {
            RuntimeHelpers.InitialiseStatics();

            //To enable multiboot vbe. check out CS2ASM/Amd64/EntryPoint.asm
            if (Multiboot.VBEInfo->PhysBase !=0)
            {
                BGA.Ptr = (uint*)(Multiboot.VBEInfo->PhysBase);
                BGA.SetVideoMode(1024, 768);
            }
            else
            {
                BGA.Setup();
                BGA.SetVideoMode(800, 600);
            }
            PS2Mouse.X = 800/2;
            PS2Mouse.Y = 600/2;

            int[] cursor = new int[]
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

            for (; ; )
            {
                BGA.Clear(0x0);
                ASC16.DrawString("FPS: ", 10, 10, 0xFFFFFFFF);
                ASC16.DrawString(((ulong)FPSMeter.FPS).ToString(), 42, 10, 0xFFFFFFFF);
                DrawCursor(cursor, PS2Mouse.X, PS2Mouse.Y);
                BGA.Update();
                FPSMeter.Update();
            }

            /*
            ACPI.Initialize();

            //Banner();
            
            Console.WriteLine("Shutdown After 2 Seconds");

            Serial.WriteLine("Hello World From OS!");

            PIT.Wait(2000);
            ACPI.Shutdown();

            for (; ; )
            {
                char c = Console.ReadKey();
                if (c == '\n')
                {
                    Console.WriteLine();
                }
                else if (c == '\b')
                {
                    Console.Back();
                }
                else
                {
                    Console.Write(c);
                }
                asm("hlt");
            }
            */
        }

        private static void DrawCursor(int[] cursor, int x, int y)
        {
            for (int h = 0; h < 21; h++)
                for (int w = 0; w < 12; w++)
                {
                    if (cursor[h * 12 + w] == 1)
                        BGA.DrawPoint(w + x, h + y, 0xFFFFFFFF);

                    if (cursor[h * 12 + w] == 2)
                        BGA.DrawPoint(w + x, h + y, 0x0);
                }
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
