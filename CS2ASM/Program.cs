/*
 * Reference: 
 * https://sharplab.io/
 */

using CS2ASM.AMD64;
using dnlib.DotNet;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using DiscUtils.Iso9660;

namespace CS2ASM
{
    internal class Program
    {
        public static readonly ProcessorArchitecture ProcessorArchitecture = ProcessorArchitecture.Amd64;
        public static BaseArch arch;

        public static void Main(string[] args)
        {
            if (args.Length < 2) 
            {
                Console.WriteLine("Usage: CS2ASM <input> <output>");
                Environment.Exit(1);
            }

            var input = args[0];
            var output = args[1];
            var def = ModuleDefMD.Load(input);
            var stopwatch = new Stopwatch();

            Console.WriteLine("Compiling...");
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
                    arch.Translate(meth);
                arch.InitializeStaticFields(typ);
            }
            arch.After(def);

            stopwatch.Stop();
            Console.WriteLine($"Finished compiling! Took {stopwatch.ElapsedMilliseconds} ms.\nAssembling...");
            stopwatch.Restart();
            
            File.WriteAllText("Tools/Kernel.asm", arch.text.ToString());
            Utility.Start("nasm", "-felf64 EntryPoint.asm -o kernel.bin", "Tools");
            Utility.Start("ld", "-Ttext=0x100000 -melf_x86_64 -o kernel.elf kernel.bin", "Tools");

            stopwatch.Stop();
            Console.WriteLine($"Finished assembling! Took {stopwatch.ElapsedMilliseconds} ms.\nGenerating image...");
            stopwatch.Restart();

            using var boot = File.OpenRead("Tools/limine/limine-cd.bin");
            using var stream = File.Create(output);

            var iso = new CDBuilder
            {
                UseJoliet = true,
                VolumeIdentifier = "CS2ASM",
                UpdateIsolinuxBootTable = true
            };
            iso.AddFile("limine-cd.bin", boot);
            iso.AddFile("limine.sys", "Tools/limine/limine.sys");
            iso.AddFile("limine.cfg", "Tools/limine/limine.cfg");
            iso.AddFile("kernel.elf", "Tools/kernel.elf");
            iso.SetBootImage(boot, BootDeviceEmulation.NoEmulation, 0);
            iso.Build().CopyTo(stream);

            Utility.Start("Tools/limine/limine-deploy", "--force-mbr " + output);

            stopwatch.Stop();
            Console.WriteLine($"Finished image generation! Took {stopwatch.ElapsedMilliseconds} ms.");
        }
    }
}
