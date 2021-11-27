using dnlib.DotNet;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Reflection;

namespace IL2ASM
{
    internal class Program
    {
        public static ProcessorArchitecture ProcessorArchitecture = ProcessorArchitecture.Amd64;

        static unsafe void Main(string[] args)
        {
            try
            {
                Arch arch = null;
                switch (ProcessorArchitecture)
                {
                    case ProcessorArchitecture.Amd64:
                        arch = new Amd64();
                        break;
                }
                arch.Setup();

                ModuleDefMD def = ModuleDefMD.Load(@"C:\Users\nifan\source\repos\ConsoleApp1\ConsoleApp1\bin\Debug\net5.0\ConsoleApp1.dll");
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                arch.Compile(def.EntryPoint, true);
                foreach (var typ in def.Types)
                {
                    foreach (var meth in typ.Methods)
                    {
                        if (meth.FullName != def.EntryPoint.FullName)
                            arch.Compile(meth);
                    }
                }

                stopwatch.Stop();
                Console.WriteLine($"{stopwatch.Elapsed.TotalSeconds} Seconds");

                switch (ProcessorArchitecture)
                {
                    case ProcessorArchitecture.Amd64:
                        File.WriteAllText(@"Amd64\Kernel.asm", Arch._Code.ToString());

                        Util.Start(@"Amd64\nasm.exe", "-fbin Multiboot.asm -o main.exe");
                        ZipFile.ExtractToDirectory(@"Amd64\grub2.zip", @"Amd64\Temp\", true);
                        File.Move(@"Amd64\main.exe", @"Amd64\Temp\boot\main.exe", true);
                        Util.Start(@"Amd64\mkisofs.exe", $"-relaxed-filenames -J -R -o \"{Environment.CurrentDirectory}\\output.iso\" -b \"{@"boot/grub/i386-pc/eltorito.img"}\" -no-emul-boot -boot-load-size 4 -boot-info-table {Environment.CurrentDirectory}\\Amd64\\Temp");
                        Process.Start($"{Environment.CurrentDirectory}\\Amd64QEMU.bat");
                        break;
                }
            }
            catch (Exception E)
            {
                Console.WriteLine(E);
            }
        }
    }
}
