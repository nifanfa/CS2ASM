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
            Console.WriteLine($"Finished compiling! Took {stopwatch.ElapsedMilliseconds} ms.");

            File.WriteAllText("Tools/Kernel.asm", arch.text.ToString());
            Console.WriteLine("Generating image...");
            stopwatch.Restart();

            Utility.Start("nasm", "-felf64 EntryPoint.asm -o kernel.bin", "Tools");
            Utility.Start("ld", "-Ttext=0x100000 -melf_x86_64 -o limine/kernel.elf kernel.bin", "Tools");
            Utility.Start("mkisofs", $"-relaxed-filenames -J -R -o \"{output}\" -b limine-cd.bin -no-emul-boot -boot-load-size 4 -boot-info-table \"{Environment.CurrentDirectory}/Tools/limine\"", "Tools");
            Utility.Start("limine-deploy", "../../output.iso", "Tools/limine");

            stopwatch.Stop();
            Console.WriteLine($"Finished image generation! Took {stopwatch.ElapsedMilliseconds} ms.");
        }
    }
}
