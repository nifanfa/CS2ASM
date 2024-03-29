﻿/*
 * Reference: 
 * https://sharplab.io/
 */

using CS2ASM.AMD64;
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
        public static BaseArch arch = null;

        static unsafe void Main(string[] args)
        {
            //If you are debugging check out launchSettings.json
            if(args.Length == 0) 
            {
                throw new ArgumentNullException();
            }
            ModuleDefMD def = ModuleDefMD.Load(args[0]);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            switch (ProcessorArchitecture)
            {
                case ProcessorArchitecture.Amd64:
                    arch = new Amd64(def);
                    arch.Debug = true;
                    arch.ImportTransformations(typeof(Amd64Transformation));
                    break;
            }
            arch.ImportCompilerMethods(def);
            arch.Before(def);
            arch.JumpToEntry(def);
            foreach (var typ in def.Types)
            {
                foreach (var meth in typ.Methods)
                {
                    arch.Translate(meth);
                }
                arch.InitializeStaticFields(typ);
            }
            arch.After(def);

            stopwatch.Stop();
            Console.WriteLine($"{stopwatch.Elapsed.TotalSeconds} Seconds");

            switch (ProcessorArchitecture)
            {
                case ProcessorArchitecture.Amd64:
                    File.WriteAllText(@"Amd64\Kernel.asm", arch.text.ToString());

                    Utility.Start(@"Amd64\nasm.exe", "-fbin EntryPoint.asm -o kernel");
                    File.Move(@"Amd64\kernel", @"Amd64\grub2\boot\kernel", true);
                    Utility.Start(@"Amd64\mkisofs.exe", $"-relaxed-filenames -J -R -o \"{Environment.CurrentDirectory}\\output.iso\" -b \"{@"boot/grub/i386-pc/eltorito.img"}\" -no-emul-boot -boot-load-size 4 -boot-info-table {Environment.CurrentDirectory}\\Amd64\\grub2");
                    Process.Start($"{Environment.CurrentDirectory}\\QEMU.bat");
                    break;
            }
        }
    }
}
