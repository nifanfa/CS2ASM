/*
 * Reference: 
 * https://sharplab.io/
 */

using dnlib.DotNet;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Reflection;

namespace CS2ASM
{
    internal class Program
    {
        public static ProcessorArchitecture ProcessorArchitecture = ProcessorArchitecture.Amd64;

        static unsafe void Main(string[] args)
        {
            ModuleDefMD def = ModuleDefMD.Load(@"..\..\..\..\Playground\ConsoleApp1\bin\Debug\netcoreapp3.1\ConsoleApp1.dll");

            BaseArch arch = null;
            switch (ProcessorArchitecture)
            {
                case ProcessorArchitecture.Amd64:
                    arch = new Amd64();
                    break;
            }
            //arch.DebugEnabled = false;
            arch.Setup(def);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            arch.Translate(def.EntryPoint);
            foreach (var typ in def.Types)
            {
                foreach (var meth in typ.Methods)
                {
                    if (meth.FullName != def.EntryPoint.FullName)
                        arch.Translate(meth);
                }
            }
            arch.InitializeStaticFields(def.Types);

            stopwatch.Stop();
            Console.WriteLine($"{stopwatch.Elapsed.TotalSeconds} Seconds");

            switch (ProcessorArchitecture)
            {
                case ProcessorArchitecture.Amd64:
                    //Debug C
                    CompileC(def, arch, "Test");

                    File.WriteAllText(@"Amd64\Kernel.asm", arch._Code.ToString());

                    Utility.Start(@"Amd64\nasm.exe", "-fbin Multiboot.asm -o kernel -l Kernel.lst");
                    ZipFile.ExtractToDirectory(@"Amd64\grub2.zip", @"Amd64\Temp\", true);
                    File.Move(@"Amd64\kernel", @"Amd64\Temp\boot\kernel", true);
                    Utility.Start(@"Amd64\mkisofs.exe", $"-relaxed-filenames -J -R -o \"{Environment.CurrentDirectory}\\output.iso\" -b \"{@"boot/grub/i386-pc/eltorito.img"}\" -no-emul-boot -boot-load-size 4 -boot-info-table {Environment.CurrentDirectory}\\Amd64\\Temp");
                    Process.Start($"{Environment.CurrentDirectory}\\Amd64QEMU.bat");
                    break;
            }
        }

        private static unsafe void CompileC(ModuleDefMD def, BaseArch arch,string fileNameNoExtensionAndPath)
        {
            if (!File.Exists(@"C:\mingw64\bin\gcc.exe"))
            {
                Utility.Start(@"Amd64\mingw64.exe", "-o\"C:\\\" -y");
            }
            Utility.Start(@"C:\mingw64\bin\gcc.exe", new FileInfo(def.Location).DirectoryName, @$"gcc -fno-asynchronous-unwind-tables -O2 -s -c -o {fileNameNoExtensionAndPath}.o {fileNameNoExtensionAndPath}.c");
            File.Move(new FileInfo(def.Location).DirectoryName + @$"\{fileNameNoExtensionAndPath}.o", @$"Amd64\{fileNameNoExtensionAndPath}.o", true);
            Utility.Start(@"Amd64\objconv-x64.exe", $"-fnasm {fileNameNoExtensionAndPath}.o");
            StreamReader str = new StreamReader(@$"Amd64\{fileNameNoExtensionAndPath}.asm");
            string line = string.Empty;
            while ((line = str.ReadLine()) != null)
            {
                if (line.IndexOf("global") != 0)
                {
                    arch._Code.WriteLine(line);
                }
            }
        }
    }
}
