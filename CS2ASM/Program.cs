/*
 * Reference: 
 * https://sharplab.io/
 */

using CS2ASM.AMD64;
using dnlib.DotNet;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using DiscUtils.Iso9660;

namespace CS2ASM;

internal class Program
{
    public static string NasmPath = "nasm";
    public static string LdPath = "ld";

    public static void Main(string[] args)
    {
        if (args.Length < 6) 
        {
            Console.WriteLine("Usage: CS2ASM -a<address> -c<amd64> -f<bin,elf> -t<none,iso> -o<output> <input>");
            Environment.Exit(1);
        }

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            NasmPath = "Tools/" + NasmPath;
            LdPath = "Tools/" + LdPath;
        }

        var settings = new Settings(args);
        var def = ModuleDefMD.Load(settings.InputFile);
        var stopwatch = new Stopwatch();
        var bin = Path.ChangeExtension(settings.OutputFile, "bin");
        var elf = Path.ChangeExtension(settings.OutputFile, "elf");

        Console.WriteLine("Compiling...");
        stopwatch.Start();

        BaseArch arch;
        switch (settings.Architecture)
        {
            case Architecture.Amd64:
                arch = new Amd64(def);
                arch.Debug = true;
                arch.ImportTransformations(typeof(Amd64Transformation));
                break;
            default: return;
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

        var format = "bin";
        if (settings.Format == Format.Elf)
            format = settings.Architecture == Architecture.Amd64 ? "elf64" : "elf32";

        File.WriteAllText("Tools/Kernel.asm", arch.text.ToString());
        Utility.Start(NasmPath, $"-f{format} Tools/EntryPoint.asm -o {bin}");
        if (settings.Format != Format.Bin)
            Utility.Start(LdPath, $"-Ttext={settings.BaseAddress} -melf_x86_64 -o {elf} {bin}");

        stopwatch.Stop();
        Console.WriteLine($"Finished assembling! Took {stopwatch.ElapsedMilliseconds} ms.");

        switch (settings.ImageType)
        {
            case ImageType.None: return;
            case ImageType.Iso:
            {
                Console.WriteLine("Generating ISO image...");
                stopwatch.Restart();

                using var cd = File.OpenRead("Tools/limine/limine-cd.bin");
                using var sys = File.OpenRead("Tools/limine/limine.sys");
                using var kernel = File.OpenRead(elf);
                using var stream = File.Create(settings.OutputFile);

                var iso = new CDBuilder
                {
                    UseJoliet = true,
                    VolumeIdentifier = def.Assembly.Name,
                    UpdateIsolinuxBootTable = true
                };
                var name = Path.GetFileName(elf);
                iso.AddFile("limine.sys", sys);
                iso.AddFile("limine.cfg", Encoding.ASCII.GetBytes($"TIMEOUT=0\n:{def.Assembly.Name}\nPROTOCOL=multiboot1\nKERNEL_PATH=boot:///{name}"));
                iso.AddFile(name, kernel);
                iso.SetBootImage(cd, BootDeviceEmulation.NoEmulation, 0);
                iso.Build().CopyTo(stream);

                Utility.Start("Tools/limine/limine-deploy", "--force-mbr " + settings.OutputFile);

                stopwatch.Stop();
                Console.WriteLine($"Finished ISO image generation! Took {stopwatch.ElapsedMilliseconds} ms.");
                break;
            }
            default: return;
        }
    }
}